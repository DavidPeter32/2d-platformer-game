using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatformSc : MonoBehaviour
{
    public enum State { Horizontal,Vertical }
    public State state ;
    private Rigidbody2D rb;
    public float speed = 0.1f;
    public Transform LeftPiont;
    public Transform RightPiont;
    public Transform UpPiont;
    public Transform DownPiont;
    public LayerMask Platform;
    private bool isLeftWall;
    private bool isRightWall;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        Platformmove();
    }
    void Platformmove()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void HorizontalMove()
    {
        isRightWall = Physics2D.Raycast(RightPiont.position, Vector2.right, 0.1f, Platform);
        if (isRightWall)
        {
            speed *= -1;
        }

        isLeftWall = Physics2D.Raycast(LeftPiont.position, Vector2.left, 0.1f, Platform);
        if (isLeftWall)
        {
            speed *= -1;
        }
    }
    
    
}
