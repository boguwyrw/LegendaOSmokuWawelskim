using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] AudioClip firstConversation;
    [SerializeField] AudioClip nextConversation;
    [SerializeField] GameObject[] necessaryItems;

    AudioSource audioSource;
    bool isFirstConversation = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < necessaryItems.Length; i++)
        {
            necessaryItems[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (isFirstConversation)
            {
                audioSource.clip = firstConversation;
                audioSource.Play();
                for (int j = 0; j < necessaryItems.Length; j++)
                {
                    necessaryItems[j].SetActive(true);
                }
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
