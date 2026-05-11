using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootstrapLoader : MonoBehaviour
{
    private IEnumerator Start()
    {
        // wait one frame to make sure all Awake() calls have finished
        yield return null;
        
        Debug.Log("Bootstrap loaded - redirecting to MainMenu");
        SceneManager.LoadSceneAsync("Main_Menu");
    }
}
