using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [HideInInspector] public bool isOnGrate = false;
    [HideInInspector] public bool tarIsHot = false;

    [SerializeField] GameObject fire;

    bool startInteraction = false;

    void Update()
    {
        if (isOnGrate)
        {
            if (fire.activeSelf)
            {
                tarIsHot = true;
                gameObject.layer = 9;
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
}
