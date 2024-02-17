using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class VineScript : MonoBehaviour
{
    public int result;
    public int presCount;
    public bool pooker;
    // Start is called before the first frame update
    //1 for red
    //2 for white
    //3 for rose
    //4 for red + rwhite
    //5 for red + rose
    //6 for rose + white
    //7 for all

    // Start is called before the first frame update
    void Start()
    {
        result = 0;
        presCount = 0;
        pooker = false;

}

// Update is called once per frame
void Update()
    {
        if(Input.GetKey(KeyCode.J))//red
        {
            result = 1;

            if (Input.GetKeyDown(KeyCode.J))
            {
                presCount++;
            }
            if (Input.GetKey(KeyCode.K))//red + white
            {
                result = 4;
                if (Input.GetKeyDown(KeyCode.K))
                {
                    presCount++;
                }
                if(Input.GetKey(KeyCode.L)) { result = 7;  // red + white + rose

                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        presCount++;
                    }
                }
            }
            else if(Input.GetKey(KeyCode.L))//red +rose
            {
                result = 5;
                if(Input .GetKeyDown(KeyCode.L)) { presCount++; }
                        
                if(Input.GetKey(KeyCode.K)) { result = 7;
                    if(Input.GetKeyDown(KeyCode.K)) presCount++; }//red rose white
            }
           // presCount=0;
        }


        else if(Input.GetKey(KeyCode.K)) {//white
            result = 2;
            if(Input.GetKeyDown(KeyCode.K)) { presCount++; }
           
            if( Input.GetKey(KeyCode.J))//white red
            {  
                result = 4;
                if(Input.GetKeyDown(KeyCode.J)) { presCount++; }
                if(Input.GetKey(KeyCode.L))// white red rose
                { result = 7; 
                    if( Input.GetKeyDown(KeyCode.L))
                        presCount++; 
                }
            }
            else if (Input.GetKey(KeyCode.L))//white rose
            {
                result = 6;
                
                if(Input.GetKeyDown (KeyCode.L)) { presCount++; }

                if (Input.GetKey(KeyCode.J))
                {
                    result = 7; //white rose red
                    if (Input.GetKeyDown(KeyCode.J)) presCount++;
                }
                    
            }
            //presCount = 0;
        }

        else if(Input.GetKey(KeyCode.L))// rose
        {
            result = 3;
            if (Input.GetKeyDown(KeyCode.L))
                presCount++;
            if(Input.GetKey(KeyCode.J))//rose red
            {
                result=5; 
                if(Input.GetKeyDown(KeyCode.J))
                    presCount++;
                if (Input.GetKey(KeyCode.K)) { 
                    result = 7;
                    if(Input.GetKeyDown(KeyCode.K))
                        presCount++;
                } //rose red white
            }
            else if( Input.GetKey(KeyCode.K)) { //rose white
                result = 6; 
                
                if(Input.GetKeyDown(KeyCode.K))
                    presCount++;
                if (Input.GetKey(KeyCode.J)) { result = 7;
                    if( Input.GetKeyDown(KeyCode.J))
                    presCount++;} //rose white red
            }
           // presCount = 0;
        }

        else result = 0;

        if(Input.GetKeyUp(KeyCode.J) && Input.GetKeyUp(KeyCode.K)&& Input.GetKeyUp(KeyCode.L))
            result = 0;


        if(presCount==5)
        {
            presCount = 0;
            pooker=true;
            result = 0; 
        }
    }
}
