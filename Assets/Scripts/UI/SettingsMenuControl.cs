using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuControl : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private bool _isFullScreen;

    public void FullScreenToggle()
    {
        _isFullScreen = !_isFullScreen;
        Screen.fullScreen = _isFullScreen;
    }

    public void AudioVolume(float sliderValue)
    {
        _audioSource.volume = sliderValue;
    }

    public void ChangeQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
