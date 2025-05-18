using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    public void OnPresTryAgainButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnPresMainTitleButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
