using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        audioSource.clip = clip;
    }

    public void PlaySoundEffect()
    {
        audioSource.Play();
    }
}
