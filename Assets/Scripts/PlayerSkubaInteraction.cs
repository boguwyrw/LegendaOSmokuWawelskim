using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaInteraction : MonoBehaviour
{
    int itemLayerMask = 1 << 8;
    float rangeToItem = 3.2f;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0.0f));
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, itemLayerMask))
        {
            float distanceToItem = Vector3.Distance(raycastHit.collider.transform.position, transform.position);
            //Debug.Log(distanceToItem);
            if (distanceToItem <= rangeToItem && Input.GetKeyDown(KeyCode.F))
            {
                Inventory.Instance.AddItemToInventory(raycastHit.collider.gameObject);
                raycastHit.collider.gameObject.SetActive(false);
            }
        }
    }
}
