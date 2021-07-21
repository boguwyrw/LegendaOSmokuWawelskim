using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaInteraction : MonoBehaviour
{
    int itemLayerMask = 1 << 8;
    int interactionLayerMask = 1 << 9;
    float rangeToItem = 5.2f;
    //string nameRequire;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0.0f));
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, itemLayerMask))
        {
            float distanceToItem = Vector3.Distance(raycastHit.collider.transform.position, transform.position);
            if (distanceToItem <= rangeToItem && Input.GetKeyDown(KeyCode.F))
            {
                Inventory.Instance.AddItemToInventory(raycastHit.collider.gameObject);
                raycastHit.collider.gameObject.SetActive(false);
            }
        }

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, interactionLayerMask))
        {
            float distanceToInteraction = Vector3.Distance(raycastHit.collider.transform.position, transform.position);
            if (distanceToInteraction <= rangeToItem)
            {
                int listLength = Inventory.Instance.playerItemsName.Count;
                for (int i = 0; i < listLength; i++)
                {
                    string nameRequire = raycastHit.collider.gameObject.GetComponent<Interaction>().requireName;
                    if (Inventory.Instance.playerItemsName[i].name.Equals(nameRequire))
                    {
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            raycastHit.collider.gameObject.GetComponent<Interaction>().objectCanInteract = true;
                            Inventory.Instance.RemoveItemFromInventory(Inventory.Instance.playerItemsName[i]);
                            listLength = Inventory.Instance.playerItemsName.Count;

                            int iconsLength = Inventory.Instance.inventoryIcons.Count;
                            for (int j = 0; j < iconsLength; j++)
                            {
                                if (Inventory.Instance.inventoryIcons[j].sprite != null && Inventory.Instance.inventoryIcons[j].sprite.name.Equals(nameRequire))
                                    Inventory.Instance.inventoryIcons[j].sprite = null;
                            }
                        }
                    }
                }
            }   
        }
    }
}
