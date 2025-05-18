using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<ItemData> inventoryList = new List<ItemData>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData item)
    {
        inventoryList.Add(item);
    }

    public int GetItemAmount(ItemData item)
    {
        int amount = 0;
        foreach(ItemData _item in inventoryList)
        {
            if (_item == item) amount++;
        }
        return amount;
    }

}
