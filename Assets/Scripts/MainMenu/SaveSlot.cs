using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")] [SerializeField] private string profileId = "";

    [Header("Content")] [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI cardsText;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            levelText.text = LevelDisplayNames.GetDisplayName(data.currentLevelName);

            cardsText.text = "Cards Collected: " + GetCollectedCardCount(data);

        }
    }
    
    private int GetCollectedCardCount(GameData data)
    {
        int count = 0;

        foreach (bool collected in data.cardsCollected.Values)
        {
            if (collected)
            {
                count++;
            }
        }

        return count;
    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }

}
