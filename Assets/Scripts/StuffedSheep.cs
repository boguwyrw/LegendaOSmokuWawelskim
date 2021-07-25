using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffedSheep : MonoBehaviour
{
    [SerializeField] WawelskiDragon wawelskiDragon;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;
    [SerializeField] LeaveSheepInPoint leaveSheepInPoint;
    [SerializeField] GameObject promptPanel;

    Rigidbody stuffedSheepRig;

    void Start()
    {
        stuffedSheepRig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (playerSkubaInteraction.pointedObjectName.Equals(gameObject.name) && !leaveSheepInPoint.sheepIsOnPlace)
            promptPanel.SetActive(true);
        else
            promptPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            stuffedSheepRig.isKinematic = false;
            stuffedSheepRig.useGravity = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 12 && stuffedSheepRig.useGravity == true)
        {
            wawelskiDragon.sheepEaten = true;
            gameObject.SetActive(false);
        }
    }
}
