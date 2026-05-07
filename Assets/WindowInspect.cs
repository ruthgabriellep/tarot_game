using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowInspect : MonoBehaviour
{
    public void ExitInspect()
    {
        SceneManager.LoadSceneAsync("Magician_Level_1");
    }
}