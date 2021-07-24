using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffedSheepPrompt : MonoBehaviour
{
    [SerializeField] GameObject promptPanel;
    [SerializeField] GameObject stuffedSheep;

    void Update()
    {
        if (!stuffedSheep.activeSelf)
            promptPanel.SetActive(false);
    }
}
