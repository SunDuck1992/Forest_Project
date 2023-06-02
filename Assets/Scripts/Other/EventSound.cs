using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EventSound : MonoBehaviour
{
    [SerializeField] private AudioClip _myClip;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void EventSoundManager()
    {
        _audioSource.PlayOneShot(_myClip);
    }
}
