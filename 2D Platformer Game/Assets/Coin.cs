using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Destroy(gameObject);
            PlayerController.Instance.CoinCount++;
            PlayerController.Instance.CoinCountText.text = PlayerController.Instance.CoinCount.ToString();

        }

    }
}
