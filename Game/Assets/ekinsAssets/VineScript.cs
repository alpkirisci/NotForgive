using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Windows.Speech;

public class VineScript : MonoBehaviour
{
    public Animator playerAnimator;
    
    public int result;
    public int presCount;
    public bool pooker;
    public bool eggs;

    public int damageinc = 20;
    public float speedinc = 1.35f;
    public int healthinc = 15;
    public Player p1;


    private float timer = 0f;
    private bool isTimerRunning = false;
    private bool eggTimer=true;



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
        playerAnimator = GetComponent<Animator>();
        eggs=false;
        p1 = GetComponent<Player>();
    }

   
    // Update is called once per frame
    void Update()
    {
        if (pooker == false)
        {
            if (Input.GetKey(KeyCode.J))//red
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
                    if (Input.GetKey(KeyCode.L))
                    {
                        result = 7;  // red + white + rose

                        if (Input.GetKeyDown(KeyCode.L))
                        {
                            presCount++;
                        }
                    }
                }
                else if (Input.GetKey(KeyCode.L))//red +rose
                {
                    result = 5;
                    if (Input.GetKeyDown(KeyCode.L)) { presCount++; }

                    if (Input.GetKey(KeyCode.K))
                    {
                        result = 7;
                        if (Input.GetKeyDown(KeyCode.K)) presCount++;
                    }//red rose white
                }
                // presCount=0;
            }


            else if (Input.GetKey(KeyCode.K))
            {//white
                result = 2;
                if (Input.GetKeyDown(KeyCode.K)) { presCount++; }

                if (Input.GetKey(KeyCode.J))//white red
                {
                    result = 4;
                    if (Input.GetKeyDown(KeyCode.J)) { presCount++; }
                    if (Input.GetKey(KeyCode.L))// white red rose
                    {
                        result = 7;
                        if (Input.GetKeyDown(KeyCode.L))
                            presCount++;
                    }
                }
                else if (Input.GetKey(KeyCode.L))//white rose
                {
                    result = 6;

                    if (Input.GetKeyDown(KeyCode.L)) { presCount++; }

                    if (Input.GetKey(KeyCode.J))
                    {
                        result = 7; //white rose red
                        if (Input.GetKeyDown(KeyCode.J)) presCount++;
                    }

                }
                //presCount = 0;
            }

            else if (Input.GetKey(KeyCode.L))// rose
            {
                result = 3;
                if (Input.GetKeyDown(KeyCode.L))
                    presCount++;
                if (Input.GetKey(KeyCode.J))//rose red
                {
                    result = 5;
                    if (Input.GetKeyDown(KeyCode.J))
                        presCount++;
                    if (Input.GetKey(KeyCode.K))
                    {
                        result = 7;
                        if (Input.GetKeyDown(KeyCode.K))
                            presCount++;
                    } //rose red white
                }
                else if (Input.GetKey(KeyCode.K))
                { //rose white
                    result = 6;

                    if (Input.GetKeyDown(KeyCode.K))
                        presCount++;
                    if (Input.GetKey(KeyCode.J))
                    {
                        result = 7;
                        if (Input.GetKeyDown(KeyCode.J))
                            presCount++;
                    } //rose white red
                }
                // presCount = 0;
            }

            else result = 0;

        }
        if(Input.GetKeyUp(KeyCode.J) && Input.GetKeyUp(KeyCode.K)&& Input.GetKeyUp(KeyCode.L))
            result = 0;


        if (presCount > 5)
        {
            presCount = 0;
            pooker = true;

            result = 0;
        }

        if (pooker) {
            
            playerAnimator.SetBool("POOK", true);
            
        }
        

        if (Input.GetKey(KeyCode.I))
        {
            pooker = false;
    
            playerAnimator.SetTrigger("eggDrink");
            playerAnimator.SetBool("POOK", false);
            playerAnimator.SetBool("walk", false);


            p1.damage = 15;
            p1.health = 150;
            p1.speed = 12;
        }


        if(Input.GetKeyDown(KeyCode.O) && pooker==false)
        {
            Drink(result);
            StartTimer();

           
        }
        
        
      


        if (isTimerRunning)
        {
            timer += Time.deltaTime;

            if (timer >= 4f)
            {
                // Timer has reached 10 seconds

                StopTimer();
                p1.damage = 15;
                p1.health = 150;
                p1.speed = 12;
            }
        }


        if (eggTimer)
        {
            timer += Time.deltaTime;

            if (timer >= 6f)
            {
                // Timer has reached 10 seconds

                EggStartTimer();

            }
        }


    }





    private void Drink(int choice)
    {
            if(choice==1) {
            p1.damage += damageinc;
        }
            else if(choice==2) {
           
            p1.speed *= speedinc;
                }
            else if(choice==3) {
            p1.health += healthinc;

        }
            else if(choice==4) {
            p1.damage += damageinc;
            p1.speed *= speedinc;
        }  
            else if(choice==5) {
            p1.damage += damageinc;
            p1.health += healthinc;
        }  
            else if(choice ==6) { p1.health += healthinc;
            p1.speed *= speedinc;
        } 
            else if (choice == 7) {
        p1.health += healthinc;
            p1.speed *= speedinc;
            p1.damage += damageinc;
        }

        
    }

    void StartTimer()
    {
        timer = 0f;
        isTimerRunning = true;
    }

    void StopTimer()
    {
        isTimerRunning = false;
      
    }


    void EggStartTimer()
    {
        timer = 0f;
        isTimerRunning = true;
    }

    void EggStopTimer()
    {
        isTimerRunning = false;

    }

}
