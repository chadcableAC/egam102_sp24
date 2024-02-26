using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointTester : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();

        JointAngleLimits2D limits = hinge.limits;

        // Changing limits code

        hinge.limits = limits;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
