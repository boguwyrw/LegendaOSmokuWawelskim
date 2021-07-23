using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] Text emengencyText;

    Collider[] dragonInRange;
    LayerMask dragonLayerMask = 1 << 7;

    void Update()
    {
        dragonInRange = Physics.OverlapSphere(transform.position, 8, dragonLayerMask);

        if (dragonInRange.Length > 0)
            EmergencyTestOn();
        else
            EmergencyTestOff();
    }

    public void EmergencyTestOn()
    {
        emengencyText.gameObject.SetActive(true);
    }

    public void EmergencyTestOff()
    {
        emengencyText.gameObject.SetActive(false);
    }
}
