using System.Collections;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
   [SerializeField] private GameObject card;
   [SerializeField] private GameObject itemBackground;
   
   public bool cardIsShowing;

   private bool _interactableInRange;
   
   private void Awake()
   {
      _interactableInRange = false; 
      cardIsShowing = false;
      card.SetActive(false);
      itemBackground.SetActive(false);
      
   }
   
   private void Update()
   {
      if (_interactableInRange && !InputManager.GetInstance().GetInteractPressed())
      {
         EnterCardIsShowing();
         Debug.Log("Card is showing");
      }
      else
      {
         StartCoroutine(ExitCardIsShowing());
      }
   }
   
   private void EnterCardIsShowing()
   {
         cardIsShowing = true;
         card.SetActive(true);
         itemBackground.SetActive(true);

   }
   
   private IEnumerator ExitCardIsShowing()
   {
      yield return new WaitForSecondsRealtime(10f);
      
      cardIsShowing = false;
      card.SetActive(false);
      itemBackground.SetActive(false);
      
   }
   
}
