using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Forest : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPositionInNextScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.savedPosition = spawnPositionInNextScene;
            GameManager.Instance.hasSavedPosition = true;
            SceneManager.LoadSceneAsync("Coast_Transition_Level");
        }
    }
}
