using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    public string Name;

    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public string WALK_ANIMATON = "Walk";
    public string ATTACK_ANIMATION = "Attack";


    public Character() { }
    public Character(int health, int maxHealth, int damage, string name)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.damage = damage;
        Name = name;
    }

    public virtual void attack(Character target)
    {
        target.health -= damage;
    }

    //
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
