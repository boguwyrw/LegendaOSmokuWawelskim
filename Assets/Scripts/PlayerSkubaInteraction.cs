using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaInteraction : MonoBehaviour
{
    int itemLayerMask = 1 << 8;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0.0f));
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, itemLayerMask))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Inventory.Instance.AddItemToInventory(raycastHit.collider.gameObject);
                raycastHit.collider.gameObject.SetActive(false);
            }
        }
    }
}
