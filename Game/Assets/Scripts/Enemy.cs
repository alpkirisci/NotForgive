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

    // Start is called before the first frame update
     public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;

    }




    // Update is called once per frame
    public override void Update()
    {
        agent.SetDestination(target.position);
        FaceTarget();
    }

    void FaceTarget()
    {
        var vel = agent.velocity;
        vel.z = 0;

        if (vel != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(
                                    Vector3.forward,
                                    vel
 );
        }
    }
}
