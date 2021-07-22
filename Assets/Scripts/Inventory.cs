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

    public GameObject sheepToStuffGO;
    public GameObject stuffedSheepGO;

    Transform inventorySlots;
    int inventorySpace = 5;
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

        if (Time.timeScale == 0.0f)
        {
            inventoryGO.SetActive(false);
            playerPointGO.SetActive(false);
        }
    }

    public void AddItemToInventory(GameObject item)
    {
        if (playerItemsName.Count >= inventorySpace) return;

        playerItemsName.Add(item);

        for (int i = 0; i < inventoryIcons.Count; i++)
        {
            if (inventoryIcons[i].sprite == null)
            {
                inventoryIcons[i].sprite = item.GetComponent<Image>().sprite;
                return;
            }
        }
    }

    public void RemoveItemFromInventory(GameObject item)
    {
        playerItemsName.Remove(item);
    }
}
