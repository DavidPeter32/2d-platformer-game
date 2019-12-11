using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour
{

    public Text CoinCountText;
    //public PlayerMovement Player;
    public int CoinCount = 0;
    public Transform AttackCheck;
    public LayerMask Enemy;
    private bool isAttacking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            CoinCount++;
            CoinCountText.text = CoinCount.ToString();

        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    void CheckIfAttacking()
    {
        isAttacking = Physics2D.Raycast(AttackCheck.position, Vector2.right, 0.6f, Enemy);
        if(isAttacking)
        {
             Destroy(Enemy)
        }
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Z))
        {

        }
    }*/
}
