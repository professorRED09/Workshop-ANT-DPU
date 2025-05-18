using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public InventoryPanel inventoryPanel;
    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }


    public float timeCounter;
    public ItemData targetItem;
    public int targetAmount = 5;

    public TMP_Text timeCounterText;
    public Image targetItemIcon;
    public TMP_Text targetCurrentAmountText;

    public bool isPlayerWin;

    private void Start()
    {
        targetItemIcon.sprite = targetItem.itemIcon;
    }

    private void Update()
    {
        if (isPlayerWin) return;
        if(timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCounterText.text = Convert.ToInt32(timeCounter).ToString();
            targetCurrentAmountText.text = "x" + (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString();

            if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount)
            {
                isPlayerWin = true; // player win
                ShowResultPanel();  // show result panel
            }

        }
        else // in case that player lose the game
        {
            ShowResultPanel();  // show result panel            
        }
    }

    public GameObject resultPanel;
    void ShowResultPanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        resultPanel.SetActive(true);
        if (isPlayerWin){
            
            resultPanel.GetComponent<Image>().color = new Vector4(255, 255, 255, 0.7f);  // set bg image to while color with less alpha
            resultPanel.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black; // set text color to black            
            resultPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "You win!";    // set text to show that player win the game
        }
        else
        {
            resultPanel.GetComponent<Image>().color = new Vector4(0, 0, 0, 0.7f);  // set bg image to black color with less alpha
            resultPanel.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white; // set text color to white 
            resultPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "You lose...";    // set text to show that player lose the game
        }
    }

}
