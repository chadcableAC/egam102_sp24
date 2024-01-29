using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Transform rotateHandle;

    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 ourPosition = rotateHandle.position;

        // For the direction from A to B is math for "B - A"
        Vector3 lookDirection = cameraPosition - ourPosition;

        rotateHandle.rotation = Quaternion.LookRotation(lookDirection);
    }
}
