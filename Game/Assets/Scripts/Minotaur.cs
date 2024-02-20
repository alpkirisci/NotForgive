using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    [SerializeField] private int _health = 550;
    [SerializeField] private int _damage = 33;
    [SerializeField] private float _attackDelay = 1.2f;
    [SerializeField] private float _attackWait = 2f;
    [SerializeField] private int _rotationSpeed = 360;
    [SerializeField] private float _minAttackDistance = 5f;


    public override void Awake()
    {
        base.Awake();

        health = _health;
        maxHealth = health;
        damage = _damage;
        attackDelay = _attackDelay;
        attackWait = _attackWait;
        rotationSpeed = _rotationSpeed;
        minAttackDistance = _minAttackDistance;
        healthBar.CreateHealtBar(maxHealth);

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
