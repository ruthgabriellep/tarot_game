using System.Collections;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject itemBackground;

    public bool cardIsShowing;

    public bool canShowCard;

    private static CardTrigger _instance;

    public static CardTrigger GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        cardIsShowing = false;
        card.SetActive(false);
        itemBackground.SetActive(false);
        _instance = this;

    }

    private void Update()
    {
        if (canShowCard && InputManager.GetInstance().GetInteractPressed())
        {
            EnterCardIsShowing();
            Debug.Log("Card is showing");
        }
        else
        {
            StartCoroutine(ExitCardIsShowing());
        }
    }

    public void EnterCardIsShowing()
    {

        cardIsShowing = true;
        card.SetActive(true);
        itemBackground.SetActive(true);

    }

    private IEnumerator ExitCardIsShowing()
    {
        yield return new WaitForSecondsRealtime(6f);

        cardIsShowing = false;
        card.SetActive(false);
        itemBackground.SetActive(false);

    }
}
