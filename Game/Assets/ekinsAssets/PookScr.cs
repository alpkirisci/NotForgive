using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PookScr : MonoBehaviour
{
    public Animator playerAnimator;
    public bool isActivatedValue;

    public VineScript vinescript;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        vinescript = GetComponent<VineScript>();

}

    // Update is called once per frame
    void Update()
    {
        if (vinescript.GetComponent("pooker") ==true) 
        { 
            playerAnimator.SetBool("PookCheck", true); 
        }
        

    }
}
