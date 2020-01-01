using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellGatoScript : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D collider;
    private Rigidbody2D rb;
    private bool isLedge;
    private bool isLeftWall;
    private bool isRightWall;
    public float speed=0.1f;
    private bool facingRight = false;
    public Transform LedgeCheck;
    public Transform WallCheck;
    public LayerMask Platform;
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
        HellGatoRun();
        CheckIfChangeDirectory();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Sword")
        {
            Instantiate(DeathFire, DeathFirePoint.position, DeathFirePoint.rotation);
            Destroy(gameObject);

        }
    }
    public void flipCharacter()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    void HellGatoRun()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void CheckIfChangeDirectory()
    {
        isLedge = Physics2D.Raycast(LedgeCheck.position, Vector2.down, 1f, Platform);
        Debug.Log("red has been set to " + isLedge);
        if (!isLedge )
        {
            flipCharacter();
            speed *= -1;
        }

        isRightWall = Physics2D.Raycast(WallCheck.position, Vector2.right, 0.1f, Platform);
        if (isRightWall)
        {
            flipCharacter();
            speed *= -1;
        }

        isLeftWall = Physics2D.Raycast(WallCheck.position, Vector2.left, 0.1f, Platform);
        if (isLeftWall)
        {
            flipCharacter();
            speed *= -1;
        }
    }
}

