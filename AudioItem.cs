using UnityEngine;

[System.Serializable]
public class AudioItem
{
    [HideInInspector] public AudioSource audioSource;
    public AudioClip clip;
    public string name;
    [Range(0, 1f)] public float volume;
    [Range(0, 1f)] public float pitch;
    public bool loop;
}
