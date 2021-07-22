using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] GameObject sheepSkinGO;

    bool startInteraction = false;

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
        {
            //Vector3 positionOnTable = new Vector3(GetComponent<Interaction>().objectPosition.x, GetComponent<Interaction>().objectPosition.y + 0.17f, GetComponent<Interaction>().objectPosition.z);
            Vector3 positionOnTable = transform.GetChild(0).position;
            sheepSkinGO.SetActive(true);
            sheepSkinGO.transform.position = positionOnTable;
            sheepSkinGO.GetComponent<SheepSkin>().isOnTable = true;
            sheepSkinGO.transform.parent = Inventory.Instance.sheepToStuffGO.transform;
        }
    }
}
