using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepSkin : MonoBehaviour
{
    [HideInInspector] public bool isOnTable = false;
    [HideInInspector] public bool itemWasPickedUp = false;

    [SerializeField] GameObject hotTarPref;
    [SerializeField] GameObject promptPanel;
    [SerializeField] Cauldron cauldron;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;
    [SerializeField] Table table;
    //[SerializeField] Text promptText;

    bool startInteraction = false;
    bool hotTarCreated = false;
    Vector3 sheepSkinPosition;
    Quaternion sheepSkinRotation;
    Vector3 hotTarPrefPosition;
    //string helpfulSentence = "Po³¹czê wszystko rozgrzan¹ smo³¹";

    void Update()
    {
        /*
        if (playerSkubaInteraction.pointedObjectName.Equals(gameObject.name))
        {
            if (Input.GetKeyDown(KeyCode.F))
                itemWasPickedUp = true;
        }
        */
        if (isOnTable)
        {
            if (!cauldron.tarIsHot)
                HelpfulAdvice();

            sheepSkinPosition = transform.position;
            sheepSkinRotation = transform.rotation;

            if (cauldron.tarIsHot)
                gameObject.layer = 9;

            startInteraction = GetComponent<Interaction>().objectCanInteract;
            if (startInteraction && !hotTarCreated)
            {
                hotTarPrefPosition = new Vector3(sheepSkinPosition.x, sheepSkinPosition.y + 0.05f, sheepSkinPosition.z);
                GameObject hotTarClone = Instantiate(hotTarPref, hotTarPrefPosition, sheepSkinRotation);
                hotTarClone.transform.parent = Inventory.Instance.sheepToStuffGO.transform;
                hotTarCreated = true;
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
