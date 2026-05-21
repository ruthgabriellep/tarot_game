using UnityEngine;

public class CoastMusic : MonoBehaviour
{
    [SerializeField] private AudioClip waves;
    
        void Start()
        {
            AudioManager.Instance.StopSFX();
            
            AudioManager.Instance.PlayAmbience(waves);
        }
}
