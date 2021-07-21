using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] InteractionObject interactionObject;

    [HideInInspector] public string requireName;
    [HideInInspector] public bool objectCanInteract;

    void Start()
    {
        requireName = interactionObject.requireObjectName;
    }
}
