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
    [SerializeField] GameObject playerPointGO;
    [SerializeField] IconButton[] iconsButtons;
    
    [HideInInspector] public List<GameObject> playerItemsName = new List<GameObject>();
    [HideInInspector] public int itemIndexForRemove;
    [HideInInspector] public List<Image> inventoryIcons = new List<Image>();

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
        }
        else
        {
            inventoryGO.SetActive(false);
        }
    }

    public void AddItemToInventory(GameObject item)
    {
        if (playerItemsName.Count >= inventorySpace) return;

        inventoryIcons[slotNumber].sprite = item.GetComponent<Image>().sprite;
        //inventoryIcons[slotNumber].GetComponent<Button>().interactable = true;
        
        playerItemsName.Add(item);

        slotNumber += 1;
    }

    public void RemoveItemFromInventory(GameObject item)
    {
        inventoryIcons[itemIndexForRemove].sprite = null;
        playerItemsName.Remove(item);
    }
}
