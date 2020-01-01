using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour
{

    public Text CoinCountText;
    public int CoinCount = 0;
    private enum Type {coin,fireball,healt,dash }
    private Type type;
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
    //void Collect()
    //{
        
    //}
}
