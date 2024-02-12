using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceB;

    public AudioClip sfx1;
    public AudioClip sfx2;

    private void Start()
    {
        // Gets ALL of the AudioSources connected to THIS game object
        AudioSource[] allSources = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Switch the clip and play
            audioSource.clip = sfx1;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Switch the clip and play
            audioSource.clip = sfx2;
            audioSource.Play();
        }
    }
}
