using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioClip AudioClip2;
    [Min(0)]
    public float Volume;

    private AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        Audio.Play();
    }

    public void TakeFoodAudio()
    {
        Audio.PlayOneShot(AudioClip, Volume);
    }

    public void DestroyBlock()
    {
        Audio.PlayOneShot(AudioClip2);
    }
}
