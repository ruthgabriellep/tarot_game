using System.Collections;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
   [SerializeField] private GameObject card;
   [SerializeField] private GameObject itemBackground;
   
   public bool cardIsShowing;
   
   private void Awake()
   {
      cardIsShowing = false;
      card.SetActive(false);
      itemBackground.SetActive(false);
      
   }
   
   private void Update()
   {
      if (InputManager.GetInstance().GetInteractPressed())
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
      yield return new WaitForSecondsRealtime(6f);
      
      cardIsShowing = false;
      card.SetActive(false);
      itemBackground.SetActive(false);

   }
   
}
