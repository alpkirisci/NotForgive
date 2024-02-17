using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : Character
{


    // Start is called before the first frame update
    void Start()
    {
        Speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * Speed * Time.deltaTime;
        pos.y += v * Speed * Time.deltaTime;

        transform.position = pos;
    }


}
