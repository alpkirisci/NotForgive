using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int health;
    protected int maxHealth;
    protected int damage;
    protected string Name;
    protected float speed;
    public bool dead = false;

    protected Rigidbody2D rb;
    protected Collider2D[] colliders;
    protected Animator animator;

    public string WALK_ANIMATON = "Walk";
    public string ATTACK_ANIMATION = "Attack";
    public string DEAD_ANIMATION = "Dead";


    public HealtBarScript healthBar; // needs to be addded manually since its a child's component


    public Character() { }
    public Character(int health, int maxHealth, int damage, string name)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.damage = damage;
        this.Name = name;
    }

    //
    public virtual void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.colliders = GetComponents<Collider2D>();
    }


    // Start is called before the first frame update
    public virtual void Start()
    {

        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (health <= 0)
        {
            dead = true;
            animator.SetBool(DEAD_ANIMATION, dead);
            foreach (Collider2D collider in colliders) { collider.enabled = false; }
        }
        else
            healthBar.setHealth(health);
        
    }


    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.setHealth(health);

    }


}
