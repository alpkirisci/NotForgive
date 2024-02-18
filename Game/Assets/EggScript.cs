using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class EggScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Set the condition value in the Animator
    }

    private void Update()
    {
        // Check if the animation is at its last frame
        if (IsAtLastFrame() && animator.GetBool("isCrack"))
        {
            // Set the boolean parameter to false
            animator.SetBool("isCrack", false);
        }
    }

    private bool IsAtLastFrame()
    {
        // Get the current state of the animation
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Check if the animation is at its last frame
        return stateInfo.normalizedTime >= 1f && stateInfo.loop == false;
    }
}

