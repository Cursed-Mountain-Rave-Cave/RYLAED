using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFM : MonoBehaviour
{
    AudioSource RadioMusic;
    AudioClip[] sounds;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    void Start()
    {
        sounds = new AudioClip[6];
        sounds[0] = one;
        sounds[1] = two;
        sounds[2] = three;
        sounds[3] = four;
        sounds[4] = five;
        sounds[5] = six;
        RadioMusic = GetComponent<AudioSource>();
        RadioMusic.clip = sounds[Random.Range(0, sounds.Length)];
        RadioMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
