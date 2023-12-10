using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    [SerializeField] private AudioClip[] audios;

    private AudioSource controlAudio;

    private void Awake()
    {
        _instance = this;
        controlAudio = GetComponent<AudioSource>();
    }

    public void PlaySFX(int index, float vol=1f)
    {
        controlAudio.PlayOneShot(audios[index], vol);
    }
}
