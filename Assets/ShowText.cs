using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowText : MonoBehaviour
{
    public GameObject textObject;
    public Button otherButton;
    public float displayTime = 3f;

    public void OnButtonClick()
    {
        textObject.SetActive(true);
        
        if (otherButton != null)
            otherButton.interactable = false;
        
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        
        textObject.SetActive(false);
        
        if (otherButton != null)
            otherButton.interactable = true;
    }
}