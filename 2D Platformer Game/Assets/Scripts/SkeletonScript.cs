using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    private enum State { start,rise,walk,goback}
    private State state;
    public float speed;
    private float playerDifference;
    public float followRange;
    private bool followPlayer;
    private bool facingRight = true;
    private Animator anim;
    private PolygonCollider2D collider;
    private Rigidbody2D rb;
    public GameObject DeathFire;
    public Transform DeathFirePoint;
    private float AnimTimerStart = 0.33f;
    private float AnimTimerFinish = 0;
    private float AnimTimerCooldown = 0.33f;
    private bool hadRisen;
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("State", (int)state);
        folowplayer();
        StateSet();
    }
    void folowplayer()
    {
        playerDifference = PlayerController.Instance.gameObject.transform.position.x - transform.position.x;
        if ((Mathf.Abs(playerDifference) < followRange))
        {
            followPlayer = true;
        }
        else
        {
            followPlayer = false;
        }
        if (followPlayer)
        {
            state = State.walk;
            if (playerDifference < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (facingRight == true)
                {
                    flipCharacter();
                }
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (facingRight == false )
                {
                   flipCharacter();
                }
            }
        }
    }
    public void flipCharacter()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Sword")
        {
            Instantiate(DeathFire, DeathFirePoint.position, DeathFirePoint.rotation);
            Destroy(gameObject);

        }
    }
    private void StateSet()
    {
        if (followPlayer&& AnimTimerStart > 0)
        {
            state = State.rise;
            AnimTimerStart = AnimTimerStart - Time.deltaTime;
        }
        else if(followPlayer && AnimTimerStart <= 0)
        {
            state = State.walk;
            AnimTimerFinish = AnimTimerCooldown;
            
        }
        else if (!followPlayer && AnimTimerFinish > 0)
        {
            state = State.goback;
            AnimTimerFinish = AnimTimerFinish - Time.deltaTime;
        }
        else if (!followPlayer && AnimTimerFinish <= 0)
        {
            state = State.start;
            AnimTimerStart = AnimTimerCooldown;
        }


    }
}
