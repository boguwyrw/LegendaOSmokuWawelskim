using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToHide : MonoBehaviour
{
    [SerializeField] WawelskiDragon wawelskiDragon;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            wawelskiDragon.reachedSafePoint = true;
        }
    }
}
