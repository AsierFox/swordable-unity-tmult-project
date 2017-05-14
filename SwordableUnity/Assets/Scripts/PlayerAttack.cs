using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Collider2D attackTrigger;

    private bool attacking;

    private float attackTimer = 0;
    private float attackCd = .55f;

    private Animator animator;

    private void Awake()
    {
        attacking = false;
        attackTrigger.enabled = false;
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("Attacking", attacking);

        if (Input.GetKeyDown("f") && !attacking)
        {
            gameObject.GetComponentInParent<Player>().PlaySound(2);
            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
