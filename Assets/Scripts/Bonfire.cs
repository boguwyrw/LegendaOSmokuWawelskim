using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] GameObject promptPanel;
    [SerializeField] GameObject firesteel;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;
    //[SerializeField] Text promptText;

    bool startInteraction = false;
    bool itemWasPickedUp = false;
    //string helpfulSentence = "Potrzebujê krzesiwa aby rozpaliæ ogieñ";

    void Start()
    {
        fire.SetActive(false);
    }

    void Update()
    {
        startInteraction = GetComponent<Interaction>().objectCanInteract;

        if (startInteraction)
            fire.SetActive(true);

        if (!itemWasPickedUp && !Inventory.Instance.playerItemsName.Any(item => item.name.Equals(firesteel.name)))
            HelpfulAdvice();
        else if (Inventory.Instance.playerItemsName.Any(item => item.name.Equals(firesteel.name)))
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
