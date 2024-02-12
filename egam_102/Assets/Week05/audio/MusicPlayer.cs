using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        // Find ALL of the music players in the scene
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();

        // If there's more than one, delete ourselves
        if (musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        // Otherwise make sure we won't be deletd on reloads
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
