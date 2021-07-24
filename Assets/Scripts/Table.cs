using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] GameObject sheepSkinGO;
    [SerializeField] GameObject promptPanel;
    [SerializeField] GameObject sheepSkin;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;
    //[SerializeField] Text promptText;

    bool startInteraction = false;
    bool itemWasPickedUp = false;
    //string helpfulSentence = "Hmmm ... Muszê poszukaæ skóry owcy";

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
        {
            Vector3 positionOnTable = transform.GetChild(0).position;
            sheepSkinGO.SetActive(true);
            sheepSkinGO.transform.position = positionOnTable;
            sheepSkinGO.GetComponent<SheepSkin>().isOnTable = true;
            sheepSkinGO.transform.parent = Inventory.Instance.sheepToStuffGO.transform;
        }

        if (!itemWasPickedUp && !Inventory.Instance.playerItemsName.Any(item => item.name.Equals(sheepSkin.name)))
            HelpfulAdvice();
        else if (Inventory.Instance.playerItemsName.Any(item => item.name.Equals(sheepSkin.name)))
            itemWasPickedUp = true;
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
