using UnityEngine.Audio;
using UnityEngine;

// Allow unity to recognize our custom class in the inspector
[System.Serializable]

// Control what data our created sound clips will hold
public class Sound
{
    public string name;

    public AudioClip clip;

    // So that unity adds a slider in inspector to configure
    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    // Now although its public, won't show in inspector of unity
    [HideInInspector]
    public AudioSource source;
}
