using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private Transform playerSeat;

    private void Start()
    {
        CharacterController2D player = FindFirstObjectByType<CharacterController2D>();

        if (player != null)
        {
            player.EnterBoat(GetComponent<Rigidbody2D>(), playerSeat);
        }
    }
}
