using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] private Image titleImage;
    [SerializeField] private GameObject buttonsController;

    private AudioSource audioSource;
    private AudioClip introductionClip;

    public static bool isFirstGame = true;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        introductionClip = GetComponent<AudioSource>().clip;

        titleImage.gameObject.SetActive(true);
        buttonsController.SetActive(false);

        if (!isFirstGame)
        {
            audioSource.playOnAwake = false;
            audioSource.Stop();
            titleImage.gameObject.SetActive(false);
            buttonsController.SetActive(true);
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            titleImage.gameObject.SetActive(false);
            buttonsController.SetActive(true);
        }
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
}
