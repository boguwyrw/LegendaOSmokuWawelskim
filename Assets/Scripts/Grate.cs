using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grate : MonoBehaviour
{
    [SerializeField] GameObject cauldronGO;
    [SerializeField] GameObject promptPanel;
    [SerializeField] GameObject cauldron;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;

    bool startInteraction = false;
    bool cauldronOnGrate = false;
    bool itemWasPickedUp = false;
    //string helpfulSentence = "Dobrze bêdzie rozgrzaæ smo³ê";

    void Update()
    {
        if (!itemWasPickedUp && !Inventory.Instance.playerItemsName.Any(item => item.name.Equals(cauldron.name)))
            HelpfulAdvice();
        else if (Inventory.Instance.playerItemsName.Any(item => item.name.Equals(cauldron.name)))
            itemWasPickedUp = true;

        if (!cauldronOnGrate)
        {
            startInteraction = GetComponent<Interaction>().objectCanInteract;

            if (startInteraction)
            {
                Vector3 positionOnTable = new Vector3(GetComponent<Interaction>().objectPosition.x, GetComponent<Interaction>().objectPosition.y + 1.57f, GetComponent<Interaction>().objectPosition.z);
                cauldronGO.SetActive(true);
                cauldronGO.transform.position = positionOnTable;
                //cauldronGO.layer = 9;
                cauldronGO.GetComponent<Cauldron>().isOnGrate = true;
                cauldronOnGrate = true;
            }
        }
    }

    void HelpfulAdvice()
    {
        if (playerSkubaInteraction.pointedObjectName.Equals(gameObject.name))
        {
            //promptText.text = helpfulSentence;
            promptPanel.SetActive(true);
        }
        else
            promptPanel.SetActive(false);
    }
}
