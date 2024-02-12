using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody2D rb;

    void Awake()
    {
        // Start frozen in air
        rb.simulated = false;
    }

    public void Fall()
    {
        // Reactive gravity
        rb.simulated = true;
    }
}
