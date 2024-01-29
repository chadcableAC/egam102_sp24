using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperGood : MonoBehaviour
{
    public Transform moveHandle;
    public float moveSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // This will move us a single frame's worth
            // This is good!  This will move the same amount regardless of framerate
            moveHandle.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}
