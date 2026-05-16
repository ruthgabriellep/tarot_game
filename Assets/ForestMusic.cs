using UnityEngine;

public class ForestMusic : MonoBehaviour
{
    [SerializeField] private AudioClip forestMusic;
    [SerializeField] private AudioClip stream;

    void Start()
    {
        AudioManager.Instance.PlayMusic(forestMusic);
        AudioManager.Instance.PlaySFX(stream);
    }

}
