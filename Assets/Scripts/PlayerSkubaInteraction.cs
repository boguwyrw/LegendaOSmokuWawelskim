using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkubaInteraction : MonoBehaviour
{
    [SerializeField] GameObject itemNamePanel;
    [SerializeField] Text itemNameText;

    int itemLayerMask = 1 << 8;
    int interactionLayerMask = 1 << 9;
    int stuffLayerMask = 1 << 10;
    float rangeToItem = 4.8f;
    Dictionary<string, string> helpfulItems = new Dictionary<string, string>();

    [HideInInspector] public bool isInPoint = false;
    [HideInInspector] public string pointedObjectName;

    void Start()
    {
        // items objects
        helpfulItems.Add("Glove", "Rêkawica");
        helpfulItems.Add("Cauldron", "Kocio³ek ze smo³¹");
        helpfulItems.Add("SheepSkin", "Skóra owcy");
        helpfulItems.Add("Firesteel", "Krzesiwo");
        helpfulItems.Add("Sulphur", "Worek z siark¹");
        helpfulItems.Add("StuffedSheep", "Wypchana owca");

        // interaction objects
        helpfulItems.Add("Bonfire", "Palenisko");
        helpfulItems.Add("Grate", "Ruszt");
        helpfulItems.Add("Table", "Stó³");
        helpfulItems.Add("HotTar", "Gor¹ca smo³a");

        // stuff object
        helpfulItems.Add("PileOfSulphur(Clone)", "Kupa siarki");

    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0.0f));
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            pointedObjectName = raycastHit.collider.name;
            itemNamePanel.SetActive(false);
        }

        //if (Physics.Raycast(ray, out raycastHit, itemLayerMask))
        if (Physics.Raycast(ray, out raycastHit))
        {
            float distanceToItem = Vector3.Distance(raycastHit.collider.transform.position, transform.position);
            if (distanceToItem <= rangeToItem && raycastHit.collider.gameObject.layer == 8)
            {
                pointedObjectName = raycastHit.collider.name;

                HelpfulObjectsRecognition(raycastHit.collider.name);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory.Instance.AddItemToInventory(raycastHit.collider.gameObject);
                    raycastHit.collider.gameObject.SetActive(false);
                }
            }
        }

        //if (Physics.Raycast(ray, out raycastHit, interactionLayerMask))
        if (Physics.Raycast(ray, out raycastHit))
        {
            float distanceToInteraction = Vector3.Distance(raycastHit.collider.transform.position, transform.position);
            if (distanceToInteraction <= rangeToItem && raycastHit.collider.gameObject.layer == 9)
            {
                pointedObjectName = raycastHit.collider.name;

                HelpfulObjectsRecognition(raycastHit.collider.name);

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

        //if (Physics.Raycast(ray, out raycastHit, stuffLayerMask))
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.transform.parent != null)
            {
                float distanceToStuff = Vector3.Distance(raycastHit.collider.transform.position, transform.position);
                if (distanceToStuff <= rangeToItem && raycastHit.collider.gameObject.layer == 10)
                {
                    pointedObjectName = raycastHit.collider.name;

                    HelpfulObjectsRecognition(raycastHit.collider.name);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Inventory.Instance.sheepToStuffGO.SetActive(false);
                        Inventory.Instance.stuffedSheepGO.SetActive(true);

                    }
                }   
            }   
        }

        if (isInPoint)
        {
            int listLength = Inventory.Instance.playerItemsName.Count;
            for (int i = 0; i < listLength; i++)
            {
                if (Inventory.Instance.playerItemsName[i].name.Equals("StuffedSheep"))
                {
                    Inventory.Instance.RemoveItemFromInventory(Inventory.Instance.playerItemsName[i]);
                    listLength = Inventory.Instance.playerItemsName.Count;

                    int iconsLength = Inventory.Instance.inventoryIcons.Count;
                    for (int j = 0; j < iconsLength; j++)
                    {
                        if (Inventory.Instance.inventoryIcons[j].sprite != null && Inventory.Instance.inventoryIcons[j].sprite.name.Equals("StuffedSheep"))
                            Inventory.Instance.inventoryIcons[j].sprite = null;
                    }
                }
            }
        }
    }

    void HelpfulObjectsRecognition(string objectName)
    {
        foreach (KeyValuePair<string, string> item in helpfulItems)
        {
            if (item.Key.Equals(objectName))
            {
                itemNamePanel.SetActive(true);
                itemNameText.text = item.Value;
            }
        }
    }
}
