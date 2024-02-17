using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField]
    private int _health;
    public int Health {  
        get { return _health; }
        set { _health = value; }
    }

    [SerializeField]
    private int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    [SerializeField]
    private int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    [SerializeField]
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }  
    }

    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATON = "Walk";


    public Character() { }
    public Character(float speed, int health, int maxHealth, int damage, string name)
    {
        Speed = speed;
        Health = health;
        MaxHealth = maxHealth;
        Damage = damage;
        Name = name;
    }

    public virtual void attack(Character target)
    {
        target.Health -= Damage;
    }



    //
    public virtual void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
