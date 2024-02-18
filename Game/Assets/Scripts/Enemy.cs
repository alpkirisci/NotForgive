using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Enemy : Character
{
    [SerializeField] Transform target;

    NavMeshAgent agent;

    [SerializeField] private int rotationSpeed = 360;
    [SerializeField] private float minAttackDistance = 5f;

    public Transform attackPoint;
    public Player player;
    public LayerMask playerLayer;
    public float attackHitBox;

    public override void Awake()
    {
        base.Awake();


        this.agent = GetComponent<NavMeshAgent>();
        this.agent.updateUpAxis = false;
        this.agent.updateRotation = false;


    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();


    }




    public bool notAttacking = true;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        agent.SetDestination(target.position);
        FaceTarget();

        Vector2 targetXY = new(target.position.x, target.position.y);
        Vector2 agentXY = new(transform.position.x, transform.position.y);

        
        if (minAttackDistance > Vector2.Distance(targetXY, agentXY) && notAttacking)
        {
            notAttacking = false;
            animator.SetTrigger("Attack");
            StartCoroutine(attackOnce());

        }

    }

    IEnumerator attackOnce()
    {
        yield return new WaitForSeconds(1.2f);
        Attack();
        yield return new WaitForSeconds(2.5f);
        notAttacking = true;
    }


    public void Attack()
    {
        Collider2D[] hitten = Physics2D.OverlapCircleAll(attackPoint.position, attackHitBox, playerLayer);
        foreach (Collider2D collider in hitten)
        {
            collider.GetComponent<Player>().health -= damage;
            Debug.Log(collider.GetComponent<Player>().health);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackHitBox);
    }

    void FaceTarget() // and walk animation sorry for putting it here
    {
        var vel = agent.velocity;
        vel.z = 0;

        if (vel != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward,vel);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
