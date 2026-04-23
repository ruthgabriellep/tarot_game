using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Magician_Level_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
