using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Enemy
{


    public override void Awake()
    {
        base.Awake();
        health = 350;
        maxHealth = health;
        damage = 25;
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
