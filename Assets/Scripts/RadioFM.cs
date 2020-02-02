using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFM : MonoBehaviour
{
    AudioSource RadioMusic;
    AudioClip[] sounds;
    public AudioClip one;
    public AudioClip two;
    void Start()
    {
        sounds = new AudioClip[2];
        sounds[0] = one;
        sounds[1] = two;
        RadioMusic = GetComponent<AudioSource>();
        RadioMusic.clip = sounds[Random.Range(0, sounds.Length)];
        RadioMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
