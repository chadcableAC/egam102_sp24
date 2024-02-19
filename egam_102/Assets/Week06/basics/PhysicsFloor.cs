using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsFloor : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    // The return type, name, and parameters need to EXACTLY match Unity's documentation
    // Note these functions only occur if at least one of the objects has a rigidbody attached

    // Enter = the first frame of the collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        myRenderer.color = Color.red;
    }

    // Stay = all of the frames between Enter and Exit
    void OnCollisionStay2D(Collision2D collision)
    {
        myRenderer.color = Color.yellow;
    }

    // Exit = the last frame of the collision
    void OnCollisionExit2D(Collision2D collision)
    {
        myRenderer.color = Color.blue;
    }

}
