using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] AudioClip firstConversation;
    [SerializeField] AudioClip nextConversation;

    AudioSource audioSource;
    bool isFirstConversation = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (isFirstConversation)
            {
                audioSource.clip = firstConversation;
                audioSource.Play();
                isFirstConversation = false;
            }
            else
            {
                audioSource.clip = nextConversation;
                audioSource.Play();
            }
        }
    }
}
