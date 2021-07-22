using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaCollision : MonoBehaviour
{
    [HideInInspector] public Vector3 pointPosition;

    Quaternion pointRotation;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            pointPosition = other.transform.position;
            pointRotation = other.transform.rotation;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 11)
        {

            int listLength = Inventory.Instance.playerItemsName.Count;
            for (int i = 0; i < listLength; i++)
            {
                if (Inventory.Instance.playerItemsName[i].name.Equals("StuffedSheep") && Input.GetKeyDown(KeyCode.F))
                {
                    Inventory.Instance.stuffedSheepGO.SetActive(true);
                    Inventory.Instance.stuffedSheepGO.transform.position = pointPosition; // daæ owcê trochê ni¿ej
                    Inventory.Instance.stuffedSheepGO.transform.rotation = pointRotation;
                    transform.GetChild(0).GetComponent<PlayerSkubaInteraction>().isInPoint = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
            transform.GetChild(0).GetComponent<PlayerSkubaInteraction>().isInPoint = false;
    }
}
