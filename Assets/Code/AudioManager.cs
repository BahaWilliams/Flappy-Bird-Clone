using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;

    private void Awake()
    {
        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipsIndex)
    {
        audioSource.PlayOneShot(clips[clipsIndex]);
    }
}
