using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    [SerializeField] AudioClip firstConversation;
    [SerializeField] AudioClip nextConversation;
    [SerializeField] GameObject kingSpeechPanel;
    [SerializeField] GameObject promptPanel;
    [SerializeField] Text kingSpeechText;
    [SerializeField] GameObject[] necessaryItems;

    AudioSource audioSource;
    bool isFirstConversation = true;
    bool kingHasBeenVisited = false;
    string firstSpeech = "Poszukaj niezbêdnych rzeczy i zg³adŸ smoka.\nJeœli Ci siê to uda ten skarb i ta korona bêd¹ Twoje.";
    string nextSpeech = "IdŸ, zg³adŸ smoka jak obieca³eœ";
    float timeToPrompt = 15.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < necessaryItems.Length; i++)
        {
            necessaryItems[i].SetActive(false);
        }

        kingSpeechPanel.SetActive(false);
        kingSpeechText.text = firstSpeech;
    }

    void Update()
    {
        if (timeToPrompt > 0)
            timeToPrompt -= Time.deltaTime;

        if (timeToPrompt <= 0.0f && !kingHasBeenVisited)
        {
            timeToPrompt = 0.0f;
            promptPanel.SetActive(true);
        }

        if (!audioSource.isPlaying)
            kingSpeechPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            kingHasBeenVisited = true;
            promptPanel.SetActive(false);

            if (isFirstConversation)
            {
                audioSource.clip = firstConversation;
                audioSource.Play();
                kingSpeechPanel.SetActive(true);
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
                kingSpeechPanel.SetActive(true);
                kingSpeechText.text = nextSpeech;
            }
        }
    }
}
