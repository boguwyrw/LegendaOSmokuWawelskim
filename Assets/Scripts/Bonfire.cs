using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] GameObject fire;

    bool startInteraction = false;

    void Start()
    {
        fire.SetActive(false);
    }

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
            fire.SetActive(true);
    }
}
