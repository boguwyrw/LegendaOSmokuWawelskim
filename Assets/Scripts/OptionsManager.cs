using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("IntroductionScene");
    }
}
