using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip waves;

    void Start()
    {
        AudioManager.Instance.PlayAmbience(waves);
    }
}
