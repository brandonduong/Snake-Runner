﻿using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public Sound[] sounds;

    // Same as start, but called RIGHT before start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        Debug.Log(name);

        // Otherwise, play sound!
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }
}
