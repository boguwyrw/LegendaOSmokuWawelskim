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
            other.gameObject.transform.localScale = new Vector3(100, 100, 100);
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 1.7f, other.gameObject.transform.position.z);
            sheepIsOnPlace = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
