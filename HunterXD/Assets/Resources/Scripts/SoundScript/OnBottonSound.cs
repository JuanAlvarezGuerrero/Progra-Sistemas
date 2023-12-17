using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBottonSound : MonoBehaviour
{
    public AudioSource sonido;
    public AudioClip sonidoMenu;

    public void PlayOnBottonSound()
    {
        sonido.clip = sonidoMenu;
        sonido.enabled = false;
        sonido.enabled = true;
    }
}
