using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public Transform moveHandle;
    public float moveSpeed;

    public Rigidbody2D rb;

    // When using physics / rigidbodies, we normally want to work with forces
    // instead of moving their transforms
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        Vector3 movementValue = Vector3.right * moveSpeed * Time.deltaTime;
    //        moveHandle.position += movementValue;
    //    }
    //}

    // We use FIXED UPDATE when working with forces / physics
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 movementValue = Vector3.right * moveSpeed * Time.fixedDeltaTime;

            rb.AddForce(movementValue, ForceMode2D.Impulse);
        }
    }
}
