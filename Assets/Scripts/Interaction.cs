using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] InteractionObject interactionObject;

    [HideInInspector] public string requireName;

    void Start()
    {
        requireName = interactionObject.requireObjectName;
    }
}
