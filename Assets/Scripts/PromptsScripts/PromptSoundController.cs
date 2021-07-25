using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptSoundController : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying && transform.GetChild(0).gameObject.activeSelf)
            audioSource.PlayOneShot(audioSource.clip);
    }
}
