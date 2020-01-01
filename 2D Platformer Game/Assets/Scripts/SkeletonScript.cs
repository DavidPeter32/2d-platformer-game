using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    private enum State { rise,walk,death }
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
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("State", (int)state);
        folowplayer();
    }
    void folowplayer()
    {
        playerDifference = PlayerController.Instance.gameObject.transform.position.x - transform.position.x;
        if ((Mathf.Abs(playerDifference) < followRange))
        {
            followPlayer = true;
           // Debug.Log(followPlayer);
            Debug.Log(playerDifference);
            state = State.rise;
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
    void SkeletonRun()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Sword")
        {
            Instantiate(DeathFire, DeathFirePoint.position, DeathFirePoint.rotation);
            Destroy(gameObject);

        }
    }
}
