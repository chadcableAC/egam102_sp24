using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody2D rb;

    void Awake()
    {
        rb.simulated = false;
    }

    public void Fall()
    {
        rb.simulated = true;
    }
}
