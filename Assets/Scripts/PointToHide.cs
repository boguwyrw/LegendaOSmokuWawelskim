using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToHide : MonoBehaviour
{
    [SerializeField] Dragon dragon;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            dragon.reachedSafePoint = true;
        }
    }
}
