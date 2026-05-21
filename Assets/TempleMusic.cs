using UnityEngine;

public class TempleMusic : MonoBehaviour
{
    [SerializeField] private AudioClip waves;
    
    void Start()
    {
        AudioManager.Instance.StopSFX();
            
        AudioManager.Instance.PlayAmbience(waves);
    }
}
