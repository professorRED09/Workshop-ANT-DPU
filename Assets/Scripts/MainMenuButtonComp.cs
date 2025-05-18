using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonComp : MonoBehaviour
{
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnPressQuitButton()
    {
        Application.Quit();
    }


}
