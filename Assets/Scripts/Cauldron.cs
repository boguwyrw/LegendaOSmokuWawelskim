using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [HideInInspector] public bool isOnGrate = false;
    [HideInInspector] public bool tarIsHot = false;
    [HideInInspector] public bool itemWasPickedUp = false;

    [SerializeField] GameObject fire;
    [SerializeField] GameObject promptPanel;
    [SerializeField] GameObject glove;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;


    bool startInteraction = false;

    void Update()
    {
        if (isOnGrate)
        {
            gameObject.layer = 9;
            if (fire.activeSelf)
            {
                if (!itemWasPickedUp && !Inventory.Instance.playerItemsName.Any(item => item.name.Equals(glove.name)))
                    HelpfulAdvice();
                else if (Inventory.Instance.playerItemsName.Any(item => item.name.Equals(glove.name)))
                    itemWasPickedUp = true;

                tarIsHot = true;
                InteractionWithCauldron();
            }
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

    void HelpfulAdvice()
    {
        if (playerSkubaInteraction.pointedObjectName.Equals(gameObject.name))
        {
            promptPanel.SetActive(true);
        }
        else
            promptPanel.SetActive(false);
    }
}
