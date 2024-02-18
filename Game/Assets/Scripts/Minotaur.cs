using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{


    public override void Awake()
    {
        base.Awake();
        health = 550;
        maxHealth = health;
        damage = 33;
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
