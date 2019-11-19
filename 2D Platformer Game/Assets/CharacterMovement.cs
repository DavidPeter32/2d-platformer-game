using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed=10f;
    public float jump;
    private float moveInput;

    private RigidBody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigidBody2D>;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {

        moveInput = moveInput.GetAxis("Horizontal")
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y)
    }
    /*void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impilse);
        }
         Jump()
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }*/

}
