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


    public override void Awake()
    {
        base.Awake();

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;

    }




    // Update is called once per frame
    public override void Update()
    {
        agent.SetDestination(target.position);
        FaceTarget();

        Vector2 targetXY = new(target.position.x, target.position.y);
        Vector2 agentXY = new(transform.position.x, transform.position.y);

        
        if (minAttackDistance > Vector2.Distance(targetXY, agentXY))
        {
            animator.SetTrigger("Attack");
        }


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
