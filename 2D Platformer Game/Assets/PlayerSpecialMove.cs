//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerSpecialMove : MonoBehaviour
////{
////    private int mana = 10;
////    public GameObject Fireball;
////    public Transform ShotPoint;
////    private float SpecialAbilityTimer = 0;
////    private float SpecialAbilityCoolDown = 0.9f;
////    private float dashspeed = 2f;
////    public GameObject DashWind;
////    public Transform DashPoint;
////    private Rigidbody2D rb;
////    void Start()
////    {
////        rb = GetComponent<Rigidbody2D>();
////    }

////    // Update is called once per frame
////    void Update()
////    {
////        PlayerAttackFireball();
////    }
////    void PlayerAttackFireball()
////    {
////        if (SpecialAbilityTimer <= 0)
////        {
////            if (Input.GetKeyDown(KeyCode.X) && mana > 0)
////            {

////                Instantiate(Fireball, ShotPoint.position, ShotPoint.rotation);
////                SpecialAbilityTimer = SpecialAbilityCoolDown;
////                mana--;
////            }
////        }
////        else
////        {
////            SpecialAbilityTimer -= Time.deltaTime;
////        }
        
////    }
    
////}
