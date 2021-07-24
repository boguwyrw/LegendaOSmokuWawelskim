using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] Image titleImage;
    [SerializeField] GameObject legendTextPanel;
    [SerializeField] GameObject buttonsController;
    [SerializeField] Button skipButton;
    [SerializeField] AudioClip[] audioClips;

    AudioSource audioSource;
    int clipNumber = 0;
    bool introPlayed = false;

    public static bool isFirstGame = true;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        titleImage.gameObject.SetActive(true);
        legendTextPanel.SetActive(false);
        buttonsController.SetActive(false);

        if (!isFirstGame)
        {
            //audioSource.playOnAwake = false;
            audioSource.Stop();
            titleImage.gameObject.SetActive(false);
            legendTextPanel.SetActive(false);
            skipButton.gameObject.SetActive(false);
            buttonsController.SetActive(true);
        }

        Time.timeScale = 1.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        if (isFirstGame)
        {
            PlayClips();
            clipNumber += 1;
        }
            
    }
    
    void Update()
    {
        if (isFirstGame)
        {
            if (!audioSource.isPlaying && !introPlayed)
            {
                titleImage.gameObject.SetActive(false);
                PlayClips();
                legendTextPanel.SetActive(true);
                introPlayed = true;
            }

            if (!audioSource.isPlaying && introPlayed)
            {
                legendTextPanel.SetActive(false);
                skipButton.gameObject.SetActive(false);
                buttonsController.SetActive(true);
            }
        }   
    }

    void PlayClips()
    {
        audioSource.clip = audioClips[clipNumber];
        audioSource.Play();
    }
    
    public void PlayButton()
    {
        isFirstGame = false;
        SceneManager.LoadScene("GameScene");
    }

    public void OptionsButton()
    {
        isFirstGame = false;
        SceneManager.LoadScene("OptionsScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SkipButton()
    {
        isFirstGame = false;
        audioSource.Stop();
        titleImage.gameObject.SetActive(false);
        legendTextPanel.SetActive(false);
        buttonsController.SetActive(true);
        skipButton.gameObject.SetActive(false);
    }
}
