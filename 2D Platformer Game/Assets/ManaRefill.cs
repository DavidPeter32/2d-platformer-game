using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRefill : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerController.Instance.mana < 10)
            {
                PlayerController.Instance.mana++;
            }
            Destroy(gameObject);
        }
    }
}
