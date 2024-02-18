using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    public float speed = 5;
    public Animator playerAnimator;
    public float rotationSpeed = 90f;
    public float tolerance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
       
          Vector2 pos = transform.position;
        
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;

        if(v != 0 || h!=0)
        {
            playerAnimator.SetBool("walk",true);
        }
        else { playerAnimator.SetBool("walk", false); }
        

        float rotationAmount=0;

        Quaternion rot =transform.rotation;
        Quaternion leftLimit = Quaternion.Euler(0, 0, 90);
        Quaternion rightLimit = Quaternion.Euler(0, 0, -90);
        Quaternion upLimit = Quaternion.Euler(0, 0, 0);
        Quaternion bottomLimit = Quaternion.Euler(0, 0, -180);
        Quaternion upLeftLimit = Quaternion.Euler(0, 0, 45);
        Quaternion upRightLimit = Quaternion.Euler(0, 0, -45);
        Quaternion bottomLeftLimit = Quaternion.Euler(0, 0, 135);
        Quaternion bottomRightLimit = Quaternion.Euler(0, 0, -135);

        

        if (Input.GetKey(KeyCode.A) && !QuaternionCompare(rot, leftLimit))
        {
          
            if (Input.GetKey(KeyCode.W) && !QuaternionCompare(rot, upLeftLimit))
            {
                rotationAmount -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            else {
                rotationAmount += rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            

        }

       
        

        else if(Input.GetKey(KeyCode.D)&& !QuaternionCompare(rot, rightLimit))
        {
            if (Input.GetKey(KeyCode.W) && !QuaternionCompare(rot, upRightLimit))
            {
                rotationAmount += rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            else if( !Input.GetKey(KeyCode.S))
            {
                rotationAmount -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }

            
        }



        else if (Input.GetKey(KeyCode.W) && !QuaternionCompare(rot, upLimit))
        {

            if (Input.GetKey(KeyCode.A) && !QuaternionCompare(rot, upRightLimit))
            {
                rotationAmount -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            else if( Input.GetKey(KeyCode.D) && !QuaternionCompare(rot, upLeftLimit))
            {
                rotationAmount += rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            else
            {
                rotationAmount -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }

        }

        else if (Input.GetKey(KeyCode.S) && !QuaternionCompare(rot, bottomLimit))
        {
            

             if (Input.GetKey(KeyCode.D) && !QuaternionCompare(rot, bottomRightLimit))
            {
                rotationAmount += rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            else if (Input.GetKey(KeyCode.A) && !QuaternionCompare(rot, bottomLeftLimit))
            {
                rotationAmount -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
            else
            {
                rotationAmount -= rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
        }



        /*
        
         if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && !QuaternionCompare(rot, upLeftLimit))
        {
            rotationAmount -= rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
        }

              if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !QuaternionCompare(rot, upRightLimit))
        {
            rotationAmount -= rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
        }

        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !QuaternionCompare(rot, bottomLeftLimit))
        {
            rotationAmount -= rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
        }

        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && !QuaternionCompare(rot, bottomRightLimit))
        {
            rotationAmount -= rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
        }
        */


       

    }
    bool QuaternionCompare(Quaternion a, Quaternion b)
    {
        // Calculate the difference between quaternions
        float angleDifference = Quaternion.Angle(a, b);

        // Check if the difference is within the tolerance level
        return angleDifference < tolerance;
    }


}
