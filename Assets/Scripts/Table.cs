using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] GameObject sheepSkin;

    private bool startInteraction = false;

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
        {
            Vector3 positionOnTable = new Vector3(GetComponent<Interaction>().objectPosition.x, GetComponent<Interaction>().objectPosition.y+0.52f, GetComponent<Interaction>().objectPosition.z);
            sheepSkin.SetActive(true);
            sheepSkin.transform.position = positionOnTable;
            sheepSkin.layer = 9;
        }
    }
}
