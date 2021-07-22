using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveSheepInPoint : MonoBehaviour
{
    [HideInInspector] public bool sheepIsOnPlace = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("StuffedSheep"))
        {
            sheepIsOnPlace = true;
        }
    }
}
