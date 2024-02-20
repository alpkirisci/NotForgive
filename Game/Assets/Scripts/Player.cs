using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{

    [SerializeField] private int _health = 550;
    [SerializeField] private int _damage = 33;
    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float rotationSpeed = 360.0f;

    //attack related
    [SerializeField] private float attackDelay;
    [SerializeField] private float attackWait;
    [SerializeField] private bool notAttacking = true;


    public Transform attackPoint;
    public LayerMask enemyLayer;
    public float attackHitBox;

    private AudioManager audioManager;


    public SpriteRenderer spriteRenderer;



    public override void Awake()
    {
        base.Awake();

        health = _health;
        maxHealth = health;
        damage = _damage;
        speed = _speed;

        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar.CreateHealtBar(maxHealth);
        audioManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioManager>();

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame

    public override void Update()
    {
        if (!dead)
        {
            base.Update();


            playerMove();

            if (Input.GetKeyDown("space") && notAttacking)
            {
                notAttacking = false;
                animator.SetTrigger(ATTACK_ANIMATION);
                audioManager.PlaySFX(audioManager.punch);
                StartCoroutine(Attack());
            }
        }

    }





    public void playerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;

        Vector2 movementDirection = new Vector2(h, v);

        if (movementDirection != Vector2.zero)
        {
            animator.SetBool(WALK_ANIMATON, true);
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else { animator.SetBool(WALK_ANIMATON, false); }
    }



    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackDelay);
        Collider2D[] hitten = Physics2D.OverlapCircleAll(attackPoint.position, attackHitBox, enemyLayer);
        foreach (Collider2D collider in hitten)
        {
            collider.GetComponent<Enemy>().takeDamage(damage);
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


}



