using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSkin : MonoBehaviour
{
    [HideInInspector] public bool isOnTable = false;

    private bool startInteraction = false;

    void Update()
    {
        if (isOnTable)
        {
            startInteraction = GetComponent<Interaction>().objectCanInteract;
            if (startInteraction)
            {

            }
        }
    }
}
