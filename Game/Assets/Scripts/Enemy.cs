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

    protected int rotationSpeed;
    protected float minAttackDistance;
    protected float attackDelay;
    protected float attackWait;

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
        if (!dead)
        {
            base.Update();

            agent.SetDestination(target.position);
            FaceTarget();

            Vector2 targetXY = new(target.position.x, target.position.y);
            Vector2 agentXY = new(transform.position.x, transform.position.y);


            if (minAttackDistance > Vector2.Distance(targetXY, agentXY) && notAttacking)
            {
                notAttacking = false;
                animator.SetTrigger(ATTACK_ANIMATION);
                StartCoroutine(Attack());
            }
        }

    }


    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackDelay);
        Collider2D[] hitten = Physics2D.OverlapCircleAll(attackPoint.position, attackHitBox, playerLayer);
        foreach (Collider2D collider in hitten)
        {
            collider.GetComponent<Player>().takeDamage(damage);
            Debug.Log("Hit!");
        }
        yield return new WaitForSeconds(attackWait);
        notAttacking = true;
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
            animator.SetBool(WALK_ANIMATON, true);
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward,vel);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
