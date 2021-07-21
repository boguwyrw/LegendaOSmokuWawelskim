using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [HideInInspector] public bool isOnGrate = false;
    [HideInInspector] public bool tarIsHot = false;

    [SerializeField] GameObject fire;

    bool startInteraction = false;
    float timeToHeatTar = 5.0f;

    void Update()
    {
        if (isOnGrate && fire.activeSelf)
        {
            tarIsHot = true;
            InteractionWithCauldron();
            /*
            timeToHeatTar -= Time.deltaTime;

            if (timeToHeatTar <= 0.0f)
            {
                tarIsHot = true;
                InteractionWithCauldron();
            }
            */
        }
    }

    void InteractionWithCauldron()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;
        if (startInteraction)
        {
            gameObject.layer = 8;
            isOnGrate = false;
        }
    }
}
