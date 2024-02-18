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

    public Rigidbody2D rb;
    public Animator animator;

    public string WALK_ANIMATON = "Walk";
    public string ATTACK_ANIMATION = "Attack";

    public HealtBarScript healthBar;


    public Character() { }
    public Character(int health, int maxHealth, int damage, string name)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.damage = damage;
        this.Name = name;
        healthBar = new HealtBarScript(maxHealth);
    }

    public virtual void attack(Character target)
    {
        target.health -= damage;
    }

    //
    public virtual void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        this.health = maxHealth;
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
