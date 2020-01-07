using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    
    public float speed;
    private float playerDifferenceX;
    private float playerDifferenceY;
    public float followRange;
    private bool followPlayer;
    private bool facingRight = true;
    private Rigidbody2D rb;
    public GameObject DeathFire;
    public Transform DeathFirePoint;
    void Start()
    {
        
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
        folowplayer();
        
    }
    void folowplayer()
    {
        playerDifferenceX = PlayerController.Instance.gameObject.transform.position.x - transform.position.x;
        playerDifferenceY = PlayerController.Instance.gameObject.transform.position.y - transform.position.y;
        if (Mathf.Abs(playerDifferenceX) < followRange && Mathf.Abs(playerDifferenceY) < followRange)
        {
            followPlayer = true;
        }
        else
        {
            followPlayer = false;
        }
        if (followPlayer)
        {
            if (playerDifferenceX < 0 && playerDifferenceY<0)
            {
                rb.velocity = new Vector2(-speed, -speed);
                if (facingRight == true)
                {
                    flipCharacter();
                }
            }
            if (playerDifferenceX < 0 && playerDifferenceY > 0)
            {
                rb.velocity = new Vector2(-speed, speed);
                if (facingRight == true)
                {
                    flipCharacter();
                }
            }
            if (playerDifferenceX > 0 && playerDifferenceY < 0)
            {
                rb.velocity = new Vector2(speed, -speed);
                if (facingRight == false)
                {
                    flipCharacter();
                }
            }
            if (playerDifferenceX > 0 && playerDifferenceY > 0)
            {
                rb.velocity = new Vector2(speed, speed);
                if (facingRight == false)
                {
                    flipCharacter();
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
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
   
}
