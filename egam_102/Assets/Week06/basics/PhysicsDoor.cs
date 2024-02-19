using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDoor : MonoBehaviour
{
    public Collider2D doorCollider;

    // The return type, name, and parameters need to EXACTLY match Unity's documentation
    // Note these functions only occur if at least one of the objects has a rigidbody attached

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Only open the door if there's a "DoorEnterer.cs" on the transform
        DoorEnterer enterer = collider.transform.GetComponent<DoorEnterer>();
        if (enterer != null)
        {
            // Turn the door object off when someone enter's our trigger
            doorCollider.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Turn the door back on when something leaves our trigger
        doorCollider.gameObject.SetActive(true);
    }
}
