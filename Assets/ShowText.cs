using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowText : MonoBehaviour
{
    public GameObject textObject;
    public float displayTime = 3f;

    public void OnButtonClick()
    {
        textObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        textObject.SetActive(false);
    }
}