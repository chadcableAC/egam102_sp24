using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform moveHandle;

    public Vector3 originalPosition;

    private void Start()
    {
        // Remember our starting position
        originalPosition = moveHandle.position;
    }

    public void Reset()
    {
        // Go back to the original position
        moveHandle.position = originalPosition;
    }
}
