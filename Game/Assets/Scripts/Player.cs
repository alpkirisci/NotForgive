using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : Character
{
    public float speed = 15f;

    // Start is called before the first frame update
    public override void Start()
    {
    
    }

    // Update is called once per frame
    public override void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;
    }


}
