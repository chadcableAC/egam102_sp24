using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Transform moveHandle;
    public float moveSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // This will move us MOVESPEED every single frame
            // This is bad!  The distance will change based on the framerate
            moveHandle.position += Vector3.up * moveSpeed;
        }
    }
}
