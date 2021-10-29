using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound backgroundMusic;

    public List<Sound> sounds;

    // Start is called before the first frame update
    void Awake()
    {
        backgroundMusic.name = "BackgroundMusic";

        sounds.Add(backgroundMusic);
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        backgroundMusic.source.loop = true;
        Play("BackgroundMusic");
        
    }

    public void Play(string name){
        Sound s = sounds.Find(sound =>sound.name == name);
        s.source.Play();
    }

    private void AddAudioSource(Sound s, AudioClip clip, float volume, float pitch)
    {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
    }

}
