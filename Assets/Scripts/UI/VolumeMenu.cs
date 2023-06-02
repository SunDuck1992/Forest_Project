using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = FindObjectOfType<Sound>().GetComponent<AudioSource>();
    }

    public void SelectVolume(float sliderValue)
    {
        _audioSource.volume = sliderValue;
    }
}
