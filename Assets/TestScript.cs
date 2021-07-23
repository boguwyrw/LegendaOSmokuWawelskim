using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    Collider[] playerInSneakingRange;
    Collider[] playerInWalkingRange;
    LayerMask playerLayerMask = 1 << 6;
    float sneakingRange = 6.0f;
    float walkingRange = 12.0f;

    void Update()
    {
        /*
        playerInSneakingRange = Physics.OverlapSphere(transform.position, sneakingRange, playerLayerMask);
        playerInWalkingRange = Physics.OverlapSphere(transform.position, walkingRange, playerLayerMask);

        foreach (Collider player in playerInSneakingRange)
        {
            player.GetComponent<PlayerTest>().EmergencyTestOn();
        }

        foreach (Collider player in playerInWalkingRange)
        {
            player.GetComponent<PlayerTest>().EmergencyTestOff();
        }
        */
    }
}
