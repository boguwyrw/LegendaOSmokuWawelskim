using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveSheepInPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            //other.transform.GetChild(0).GetComponent<PlayerSkubaInteraction>().isInPoint = true;
        }
    }
}
