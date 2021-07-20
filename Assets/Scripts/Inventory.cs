using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    List<GameObject> playerItems = new List<GameObject>();
    int inventorySpace = 5;

    public void AddItemToInventory(GameObject item)
    {
        //if (playerItems.Count >= inventorySpace) return;

        playerItems.Add(item);
    }

    public void RemoveItemToInventory(GameObject item)
    {
        playerItems.Remove(item);
    }
}
