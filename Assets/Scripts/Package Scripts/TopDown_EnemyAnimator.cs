using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_EnemyAnimator : MonoBehaviour
{
    public bool IsAttacking { get; private set; }

    public GameManager gm;
    Vector3 prevPos;
    [SerializeField] Animator anim;
    public float enemyCooldown;

    // Start is called before the first frame update
    private void Start()
    {
        enemyCooldown = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        enemyCooldown -= Time.deltaTime;
        
        Vector3 movement = transform.position - prevPos;

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            if (movement.x > 0f)
            {
                anim.SetInteger("Direction", 0);
            }
            if (movement.x < 0f)
            {
                anim.SetInteger("Direction", 2);
            }
        }
        else
        {
            if (movement.y > 0f)
            {
                anim.SetInteger("Direction", 1);
            }
            if (movement.y < 0f)
            {
                anim.SetInteger("Direction", 3);
            }
        }

        prevPos = transform.position;

        IsAttacking = anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
        
        if (enemyCooldown <= 0)
        {
            print("callAttack" + enemyCooldown);
            Attack();
            enemyCooldown = 4;
        }
    }

    // Call this function from another script for the orc to attack!
    public void Attack()
    {
        anim.SetTrigger("Attack");
        print("functionAttack");
        gm.ChangeHealth(-1);
    }
}
