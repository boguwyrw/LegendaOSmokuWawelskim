using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] InteractionObject interactionObject;

    [HideInInspector] public string requireName;
    [HideInInspector] public bool objectCanInteract;
    [HideInInspector] public Vector3 objectPosition;

    void Start()
    {
        requireName = interactionObject.requireObjectName;
        objectPosition = transform.position;
    }
}
