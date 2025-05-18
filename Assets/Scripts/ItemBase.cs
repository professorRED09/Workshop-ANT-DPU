using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public ItemData item;

    public void Interact()
    {
        print("Interact Item: " + item.name);
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
    }
}
