using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundFX;
    public AudioSource audioSource;

    void Start() 
    {
        audioSource.clip = null;
    }
}
