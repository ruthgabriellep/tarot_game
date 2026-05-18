using UnityEngine;

public class CliffMusic : MonoBehaviour
{
    [SerializeField] private AudioClip waves;

    void Start()
    {
        AudioManager.Instance.StopSFX();
        
        AudioManager.Instance.PlayAmbience(waves);
    }
}
