using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grate : MonoBehaviour
{
    [SerializeField] GameObject cauldronGO;

    private bool startInteraction = false;

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
        {
            Vector3 positionOnTable = new Vector3(GetComponent<Interaction>().objectPosition.x, GetComponent<Interaction>().objectPosition.y + 1.57f, GetComponent<Interaction>().objectPosition.z);
            cauldronGO.SetActive(true);
            cauldronGO.transform.position = positionOnTable;
            cauldronGO.layer = 9;
            cauldronGO.GetComponent<Cauldron>().isOnGrate = true;
        }
    }
}
