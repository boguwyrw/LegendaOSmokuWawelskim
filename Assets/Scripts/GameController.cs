using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController Instance;

    void Awake()
    {
        if (Instance != null) return;

        Instance = this;
    }
    #endregion

    [SerializeField] Text winText;
    [SerializeField] Text gameOverText;
    [SerializeField] Button exitButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void WinGameController()
    {
        winText.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void LoseGameController()
    {
        gameOverText.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("IntroductionScene");
    }
}
