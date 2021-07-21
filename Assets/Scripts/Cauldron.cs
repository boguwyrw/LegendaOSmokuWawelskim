using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [HideInInspector] public bool isOnGrate = false;

    [SerializeField] private GameObject fire;

    private bool startInteraction = false;
    private float timeToHeatTar = 5.0f;

    void Update()
    {
        if (isOnGrate && fire.activeSelf)
        {
            timeToHeatTar -= Time.deltaTime;

            if (timeToHeatTar <= 0.0f)
            {
                InteractionWithCauldron();
            }
            
        }
    }

    void InteractionWithCauldron()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;
        if (startInteraction)
        {

        }
    }
}
