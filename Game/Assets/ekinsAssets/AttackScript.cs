using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator attackAnimator;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public Player p1;

    public LayerMask enemyLayers;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }

    void Attack()
    {
        //Attack animation
        attackAnimator.SetTrigger("Attack");
        //detect ranged enemies

        Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        //
        foreach(Collider2D enemy in hitEnemies) 
        {
            enemy.GetComponent<Enemy>().health -= p1.damage;
        }
    
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
