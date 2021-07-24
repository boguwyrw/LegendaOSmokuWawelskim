using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [HideInInspector] public bool isOnGrate = false;
    [HideInInspector] public bool tarIsHot = false;
    [HideInInspector] public bool itemWasPickedUp = false;

    [SerializeField] GameObject fire;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;


    bool startInteraction = false;

    void Update()
    {
        if (isOnGrate)
        {
            if (fire.activeSelf)
            {
                // jak coœ to tu sprawdzac czy mam rekawice
                tarIsHot = true;
                gameObject.layer = 9;
                InteractionWithCauldron();
            }
        }

        if (playerSkubaInteraction.pointedObjectName.Equals(gameObject.name))
        {
            if (Input.GetKeyDown(KeyCode.F))
                itemWasPickedUp = true;
        }
    }

    void InteractionWithCauldron()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;
        if (startInteraction && gameObject.layer == 9)
        {
            gameObject.layer = 8;
            Inventory.Instance.AddItemToInventory(gameObject);
            gameObject.SetActive(false);
            isOnGrate = false;
        }
    }
}
