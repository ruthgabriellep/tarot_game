using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class CameraTargetSetter : MonoBehaviour
{
    private CinemachineCamera cam;

    void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            cam.Follow = player.transform;
            cam.LookAt = player.transform;
        }
    }
}
