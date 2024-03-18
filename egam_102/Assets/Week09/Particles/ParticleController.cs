using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // We only need a reference to the "root" particle
    public ParticleSystem ps;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ps.Play();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ps.Pause();
        }

        if (Input.GetMouseButtonDown(2))
        {
            // By default, stop only affects NEW emissions
            ps.Stop();

            // If we want particles to also disappear, we also need to clear them
            ps.Clear();

            // This is the same as the code above, but in one line
            //ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
