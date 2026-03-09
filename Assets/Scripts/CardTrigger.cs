using System.Collections;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject itemBackground;

    public bool cardIsShowing;

    private bool _interactableInRange;

    private static CardTrigger _instance;

    public static CardTrigger GetInstance()
    {
        return _instance;
    }
   
    private void Awake()
    {
        _interactableInRange = false; 
        cardIsShowing = false;
        card.SetActive(false);
        itemBackground.SetActive(false);
        _instance = this;

    }
   
    private void Update()
    {
        if (_interactableInRange && !InputManager.GetInstance().GetInteractPressed())
        {
            Debug.Log("Card is showing");
            EnterCardIsShowing();
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
   
    public IEnumerator ExitCardIsShowing()
    {
        yield return new WaitForSecondsRealtime(10f);

        _interactableInRange = false;
        cardIsShowing = false;
        card.SetActive(false);
        itemBackground.SetActive(false);
      
    }
   
}
