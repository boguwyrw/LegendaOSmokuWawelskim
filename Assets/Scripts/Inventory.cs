using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;

    void Awake()
    {
        if (Instance != null) return;
        
        Instance = this;
    }
    #endregion

    [SerializeField] GameObject inventoryGO;
    
    List<GameObject> playerItems = new List<GameObject>();
    List<Image> inventoryIcons = new List<Image>();
    Transform inventorySlots;
    int inventorySpace = 5;
    int slotNumber = 0;
    bool inventoryIsOpen = false;

    void Start()
    {
        inventorySlots = inventoryGO.transform.GetChild(0);
        inventoryGO.SetActive(false);

        for (int i = 0; i < inventorySlots.childCount; i++)
        {
            inventoryIcons.Add(inventorySlots.GetChild(0).transform.GetChild(0).GetComponent<Image>());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryIsOpen = !inventoryIsOpen;

        if (inventoryIsOpen)
        {
            inventoryGO.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            inventoryGO.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void AddItemToInventory(GameObject item)
    {
        if (playerItems.Count >= inventorySpace) return;

        inventoryIcons[slotNumber].sprite = item.transform.GetChild(0).GetComponent<Image>().sprite;
        inventoryIcons[slotNumber].GetComponent<Button>().interactable = true;
        playerItems.Add(item);

        slotNumber += 1;
    }

    public void RemoveItemToInventory(GameObject item)
    {
        playerItems.Remove(item);
    }
}
