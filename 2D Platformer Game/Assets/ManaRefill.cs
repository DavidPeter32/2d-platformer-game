using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRefill : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (HealthManaManager.Mana < 10)
            {
                HealthManaManager.Mana++;
            }
            Destroy(gameObject);
        }
    }
}
