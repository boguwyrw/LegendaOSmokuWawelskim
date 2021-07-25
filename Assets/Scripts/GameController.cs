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
    [SerializeField] GameObject mainLightGO;
    [SerializeField] Button exitButton;
    [SerializeField] AudioClip melancholyClip;
    [SerializeField] AudioClip medievalClip;

    Light mainLight;
    AudioSource audioSource;
    Vector3 sideDirecion;
    float lightValue = 230.0f;
    float lightRate = 0.01f;
    float dayNightTime = 0.0f;
    float dayNightValue = 12.0f;
    float multiplier = 0.0035f;
    float permanentValue = 0.2f;
    float exposureValue = 0.0f;
    bool nightIsComming = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainLight = mainLightGO.GetComponent<Light>();
        mainLight.color = new Color32((byte)lightValue, (byte)lightValue, (byte)lightValue, 255);
        dayNightTime = dayNightValue;
        SkyDayNightController();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        NightDaySystem();
        SkyDayNightController();
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

    void NightDaySystem()
    {
        if (dayNightTime > 0 && lightValue > 0)
            dayNightTime -= Time.deltaTime;

        if (lightValue > 0 && !nightIsComming && dayNightTime <= 0.0f)
        {
            lightValue -= lightRate;
        }
        else if (lightValue < 0.0f)
        {
            lightValue = 0.0f;
            dayNightTime = dayNightValue;
        }

        if (lightValue == 0.0f && dayNightTime > 0)
        {
            nightIsComming = true;
            dayNightTime -= Time.deltaTime;
        }
        
        if (dayNightTime <= 0.0f && nightIsComming)
        {
            lightValue += lightRate;
        }

        if (lightValue > 230.0f)
        {
            lightValue = 230.0f;
            nightIsComming = false;
            dayNightTime = dayNightValue;
        }

        mainLight.color = new Color32((byte)lightValue, (byte)lightValue, (byte)lightValue, 255);
    }

    void SkyDayNightController()
    {
        exposureValue = permanentValue + multiplier * lightValue;
        RenderSettings.skybox.SetFloat("_Exposure", exposureValue);
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
