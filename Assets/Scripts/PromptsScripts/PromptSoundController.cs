using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptSoundController : MonoBehaviour
{
    AudioSource audioSource;
    bool soundWasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying && transform.GetChild(0).gameObject.activeSelf && !soundWasPlayed)
        {
            audioSource.PlayOneShot(audioSource.clip);
            soundWasPlayed = true;
        }

        if (!transform.GetChild(0).gameObject.activeSelf)
            soundWasPlayed = false;
    }
}
