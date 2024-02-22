using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip[] audioClips = null;
    private AudioSource audioSource = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        SoundTest_1();
    }

    void SoundTest_1()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StopAndPlay(audioClips[0]);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            StopAndPlay(audioClips[1]);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            StopAndPlay(audioClips[2]);
        }
    }


    void StopAndPlay(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
