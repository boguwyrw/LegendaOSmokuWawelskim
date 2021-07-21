using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] GameObject sheepSkinGO;

    private bool startInteraction = false;

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
        {
            Vector3 positionOnTable = new Vector3(GetComponent<Interaction>().objectPosition.x, GetComponent<Interaction>().objectPosition.y+0.52f, GetComponent<Interaction>().objectPosition.z);
            sheepSkinGO.SetActive(true);
            sheepSkinGO.transform.position = positionOnTable;
            sheepSkinGO.layer = 9;
            sheepSkinGO.GetComponent<SheepSkin>().isOnTable = true;
        }
    }
}
