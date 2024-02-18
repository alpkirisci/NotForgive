using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    public SpriteRenderer spriteRenderer;

    public int rotationSpeed = 360;


    public override void Awake()
    {
        base.Awake();
        health = 100;
        damage = 15;
        maxHealth = health;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
       
        Vector2 pos = transform.position;
        
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;

        Vector2 movementDirection = new Vector2(h,v);

        if (movementDirection != Vector2.zero)
        {
            animator.SetBool("walk", true);
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else { animator.SetBool("walk", false); }

        
    }


}
