using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public static BgMusic BgInstance;
    public AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Stops the background music
    public void Stop()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Stop();
    }

    // Plays the background music
    public void Play()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Play();
    }
}
