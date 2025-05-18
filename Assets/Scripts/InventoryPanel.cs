using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    public Image selectedIcon;
    public TMP_Text descriptionText;
    public Transform rightPanelTransform;
    public GameObject itemButtonPrefab;

    public void OnOpen()
    {
        for(int i = rightPanelTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(rightPanelTransform.GetChild(i).gameObject);
        }

        for(int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            GameObject itemButtonObj = GameObject.Instantiate(itemButtonPrefab, rightPanelTransform);
            ItemButton itemButtonComp = itemButtonObj.GetComponent<ItemButton>();
            itemButtonComp.item = InventoryManager.instance.inventoryList[i];
            itemButtonComp.icon.sprite = itemButtonComp.item.itemIcon;
            Button button = itemButtonObj.GetComponent<Button>();

            button.onClick.AddListener(() => 
            {   selectedIcon.sprite = itemButtonComp.item.itemIcon; 
                descriptionText.text = itemButtonComp.item.description;
            });
        }
    }
}
