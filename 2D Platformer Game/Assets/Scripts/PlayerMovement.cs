using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed ;
    public float jumpForce;
    public Transform GroundCheck;
    public LayerMask Ground;
    public Collider2D AttackTrigger;
    private float moveInput;
    private bool facingRight = true;
    private bool isGrounded;
    private bool jumped;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isAttacking = false;
    private float AttackTimer = 0;
    private float AttackCoolDown= 0.3f ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        CheckIfGrounded();
        PlayerAttack();
    }
    void FixedUpdate()
    {
        PlayerWalk();
        

    }
    
    void PlayerWalk()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == true && moveInput < 0)
        {
            flip();
        }
        else if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        anim.SetInteger("Speed", Mathf.Abs((int)rb.velocity.x));
    }
    public void flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(GroundCheck.position, Vector2.down,0.1f, Ground);
        if(isGrounded)
        {
            if(jumped)
            {
                jumped = false;
                anim.SetBool("Jump", false);
            }
        }
    }
    void PlayerJump()
    {
        if(isGrounded)
        {
            if(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.UpArrow))
            {
                jumped = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("Jump", true);
            }
        }
    }
    
    void PlayerAttack()
    {
        if (Input.GetKey(KeyCode.Z) && !isAttacking)
        {
            isAttacking = true;
            AttackTrigger.enabled = true;
            anim.SetBool("Attacking", true);
            AttackTimer = AttackCoolDown;
        }
        if (AttackTimer > 0)
        {
            AttackTimer -=Time.deltaTime;
        }
        else
        {
            isAttacking = false;
            AttackTrigger.enabled = false;
            anim.SetBool("Attacking", false);
        }
    }
}
