using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //audioSource.loop = false;
            audioSource.Stop();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            //audioSource.loop = true;
        }
    }
}
