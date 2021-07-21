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
            inventoryIcons.Add(inventorySlots.GetChild(i).transform.GetChild(0).GetComponent<Image>());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryIsOpen = !inventoryIsOpen;

        if (inventoryIsOpen)
        {
            inventoryGO.SetActive(true);
            playerPointGO.SetActive(false);
        }
        else
        {
            inventoryGO.SetActive(false);
            playerPointGO.SetActive(true);
        }
    }

    public void AddItemToInventory(GameObject item)
    {
        if (playerItemsName.Count >= inventorySpace) return;

        inventoryIcons[slotNumber].sprite = item.GetComponent<Image>().sprite;

        playerItemsName.Add(item);

        slotNumber += 1;
    }

    public void RemoveItemFromInventory(GameObject item)
    {
        //inventoryIcons[itemIndexForRemove].sprite = null;
        playerItemsName.Remove(item);
    }
}
