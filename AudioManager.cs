using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Ses Ayarlarý")]
    public AudioItem[] sounds;
    public static AudioManager instance;

    public void Awake()
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
    }
    public void Start()
    {
        foreach (AudioItem sound in sounds)
        {    
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.name = sound.name;              
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }
    public void Play(string name)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            print("Ses : " + name + " bulanamdý!");
            return;
        }
        sound.audioSource.Play();
    }
    public void PlayOne(AudioClip clip)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            print("Ses : " + name + " bulanamdý!");
            return;
        }
        sound.audioSource.PlayOneShot(clip);
    }
    public void Stop(string name)
    {
        AudioItem sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            print("Ses : " + name + " bulanamdý!");
        }
        sound.audioSource.Stop();
    } 
}