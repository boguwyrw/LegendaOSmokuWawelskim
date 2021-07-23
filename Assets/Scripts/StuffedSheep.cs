using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffedSheep : MonoBehaviour
{
    [SerializeField] WawelskiDragon wawelskiDragon;

    Rigidbody stuffedSheepRig;

    void Start()
    {
        stuffedSheepRig = GetComponent<Rigidbody>();
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
