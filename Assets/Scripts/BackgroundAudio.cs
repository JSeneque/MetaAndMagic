using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [SerializeField] AudioClip _backgroundMusic;
    [SerializeField] AudioClip _winMusic;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _backgroundMusic;
        _audioSource.Play();
    }

    public void PlayWinMusic()
    {
        _audioSource.clip = _winMusic;
        _audioSource.Play();
    }
}
