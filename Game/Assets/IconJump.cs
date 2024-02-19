using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos= transform.position;

        if(Input.GetKeyDown(KeyCode.J)){


                pos.y+=14;
                
            }
        if(Input.GetKeyUp(KeyCode.J))
            pos.y-=14;

        transform.position=pos;
    }
}
