using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    // Variables
    public HingeJoint2D joint = null;
    public float motorSpeed = -100;

    void FixedUpdate()
    {
        // Only run this code if we have a joint assigned
        if (joint != null)
        {
            // Track input
            bool isInputActive = false;
            if (Input.GetMouseButton(0))
            {
                isInputActive = true;
            }

            // Change the motor direction based on the input
            float newMotorSpeed = motorSpeed;
            if (isInputActive)
            {
                newMotorSpeed *= -1f;
            }

            // Because of REASONS, we can't directly assign the motor speed
            //joint.motor.motorSpeed = newMotorSpeed;

            // Instead we need to get the motor, change the value, and reassign
            JointMotor2D motor = joint.motor;
            motor.motorSpeed = newMotorSpeed;
            joint.motor = motor;

            // This is similar to positions - we can't directly assign the X position
            //transform.position.x = 5;

            // But we CAN get the overall position, adjust the X, and reassign
            //Vector3 pos = transform.position;
            //pos.x = 5;
            //transform.position = pos;
        }
    }
}
