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

    [SerializeField] GameObject winTextPanel;
    [SerializeField] GameObject gameOverTextPanel;
    [SerializeField] Button exitButton;
    [SerializeField] AudioClip melancholyClip;
    [SerializeField] AudioClip medievalClip;

    AudioSource audioSource;
    Vector3 sideDirecion;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void WinGameController()
    {
        winTextPanel.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void LoseGameController()
    {
        gameOverTextPanel.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("IntroductionScene");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            sideDirecion = transform.InverseTransformPoint(other.transform.position);
            audioSource.Stop();
            if (audioSource.clip.name.Equals("SmokWawelskiSredniowieczna") && sideDirecion.x < 0)
            {
                audioSource.clip = melancholyClip;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = medievalClip;
                audioSource.Play();
            }
        }
    }
}
