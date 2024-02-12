using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();
        if (musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // This will keep us in teh game forever, across scene loads and reloads
            DontDestroyOnLoad(gameObject);
        }
    }
}
