using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /*private bool isAttacking = false;
    private float AttackTimer = 0;
    private float AttackCoolDown = 0.3f;
    public Collider2D AttackTrigger;
    private Animator Attack_anim;
    
    private void Awake()
    {
        Attack_anim = Player.GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Z) && !isAttacking)
        {
            isAttacking = true;
            AttackTrigger.enabled = true;
            Attack_anim.SetBool("Attacking", true);
            AttackTimer = AttackCoolDown;
        }
        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
        }
        else
        {
            isAttacking = false;
            AttackTrigger.enabled = false;
            Attack_anim.SetBool("Attacking", false);
        }
    }*/
}
