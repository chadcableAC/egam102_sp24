using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform moveHandle;

    public Vector3 originalPosition;

    private void Start()
    {
        originalPosition = moveHandle.position;
    }

    public void Reset()
    {
        moveHandle.position = originalPosition;
    }
}
