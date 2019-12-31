using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum State { idl, walk, jump, attack, jumpattack, hurt,fireball,jumpfireball,dash }
public class PlayerController : MonoBehaviour
{
    private State state = State.idl;
    public float speed;
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
    private float AttackCoolDown = 0.3f;
    private bool isHurt = false;
    public float HurtForceX;
    public float HurtForceY;
    public int health = 5;
    public Slider HP;
    public GameObject Fireball;
    public Transform ShotPoint;
    private float FireballAttackTimer;
    public float FireballAttackCoolDown;
    public static bool isFireball;

    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<PlayerController>();
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.hurt)
        {
            PlayerWalk();

        }
        //PlayerWalk();
        PlayerJump();
        CheckIfGrounded();
        PlayerAttack1();
        StateSet();
        PlayerDeath();
        anim.SetInteger("State", (int)state);
        PlayerAttackFireball();
        HP.value = health;

    }
    void FixedUpdate()
    {


    }
    void PlayerWalk()
    {
        state = State.walk;
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
    }
    public void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

    }
    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f, Ground);
        if (isGrounded)
        {
            if (jumped)
            {

                jumped = false;
                anim.SetBool("Jump", false);
            }
        }
    }
    void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {

                jumped = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("Jump", true);
            }
        }
    }
    void PlayerAttack1()
    {
        if (Input.GetKey(KeyCode.Z) && !isAttacking)
        {
            isAttacking = true;
            AttackTrigger.enabled = true;
            AttackTimer = AttackCoolDown;
        }
        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
        }
        else
        {

            isAttacking = false;
            AttackTrigger.enabled = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (state != State.attack && state != State.jumpattack)
            {
                state = State.hurt;
                health--;
                if (collision.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-HurtForceX, HurtForceY);
                }
                else
                {
                    rb.velocity = new Vector2(HurtForceX, HurtForceY);
                }
            }
        }

    }
    private void StateSet()
    {
        if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.y) < .1f)
            {
                state = State.idl;
            }
        }
        else if (jumped && isFireball)
        {
            state = State.jumpfireball;
        }
        else if (jumped && isAttacking)
        {
            state = State.jumpattack;
        }
        else if (jumped)
        {
            state = State.jump;
        }
        else if (isFireball)
        {
            state = State.fireball;
        }
        else if (isAttacking)
        {
            state = State.attack;
        }

        else if (moveInput != 0)
        {
            state = State.walk;
        }
        else
        {
            state = State.idl;
        }

    }
    void PlayerAttackFireball()
    {

        if (Input.GetKey(KeyCode.X) && !isFireball)
        {
            isFireball = true;
            Instantiate(Fireball, ShotPoint.position, ShotPoint.rotation);
            FireballAttackTimer = FireballAttackCoolDown;
        }
        if (FireballAttackTimer > 0)
        {
            FireballAttackTimer -= Time.deltaTime;
        }
        else
        {
            isFireball = false;
        }
    }
    void PlayerDeath()
    {
        if (health == 0)
        {
            //Destroy(gameObject);
        }
    }
}
