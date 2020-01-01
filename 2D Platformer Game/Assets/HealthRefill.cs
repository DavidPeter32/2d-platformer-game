using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefill : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(PlayerController.Instance.health<5)
            {
                PlayerController.Instance.health++;
            }
            Destroy(gameObject);
        }
    }
}
