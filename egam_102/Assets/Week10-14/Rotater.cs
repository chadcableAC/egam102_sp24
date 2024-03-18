using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float degreesPerSecond;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(Vector3.up * degreesPerSecond * Time.deltaTime);
    }
}
