using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefill : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (HealthManaManager.Health < 5)
            {
                HealthManaManager.Health++;
            }
            Destroy(gameObject);
        }
    }
}
