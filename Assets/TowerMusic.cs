using UnityEngine;

public class TowerMusic : MonoBehaviour
{
    // [SerializeField] private AudioClip waves;

    void Start()
    {
        AudioManager.Instance.StopSFX();
        
        // AudioManager.Instance.PlayAmbience(waves);
    }
}
