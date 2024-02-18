using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{


    public override void Awake()
    {
        base.Awake();
        health = 40;
        maxHealth = health;
        damage = 10;
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
    }
}
