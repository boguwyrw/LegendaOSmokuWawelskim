using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveSheepInPoint : MonoBehaviour
{
    [HideInInspector] public bool sheepIsOnPlace = false;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("StuffedSheep"))
        {
            sheepIsOnPlace = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
