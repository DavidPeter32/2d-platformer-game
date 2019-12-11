using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellGatoScript : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D collider;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Sword")
        {
            anim.SetBool("isDead", true);
            //Destroy(GetComponent<PolygonCollider2D>());
            Destroy(gameObject,0.40f);
            
        }
    }
}

