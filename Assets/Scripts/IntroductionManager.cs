using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] private Image titleImage;
    [SerializeField] private GameObject buttonsController;
    [SerializeField] private Button skipButton;

    private AudioSource audioSource;

    public static bool isFirstGame = true;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        titleImage.gameObject.SetActive(true);
        buttonsController.SetActive(false);

        if (!isFirstGame)
        {
            audioSource.playOnAwake = false;
            audioSource.Stop();
            titleImage.gameObject.SetActive(false);
            buttonsController.SetActive(true);
        }

        Time.timeScale = 1.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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

    public void SkipButton()
    {
        audioSource.Stop();
        titleImage.gameObject.SetActive(false);
        buttonsController.SetActive(true);
        skipButton.gameObject.SetActive(false);
    }
}
