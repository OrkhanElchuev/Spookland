using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music musicInstance;

    private void Awake()
    {
        // Check if music instance exists
        if (musicInstance == null)
        {
            musicInstance = this;
            // Dont destroy on Load of new scene
            DontDestroyOnLoad(musicInstance);
        }
        else
        {
            Destroy(musicInstance);
        }
    }
}
