using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimator : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        bool isPressed = false;
        if (Input.GetKey(KeyCode.Space))
        {
            isPressed = true;
        }

        animator.SetBool("IsPressed", isPressed);
    }
}
