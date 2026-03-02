using UnityEngine;

public class TheStarCard : MonoBehaviour, IInteractable
{

    public bool isInteracted { get; private set; }

    public string theStarCardID { get; private set; }

    public GameObject itemPrefab;
    public Sprite interactedSprite;

    void Start()
    {
        theStarCardID ??= GlobalHelper.GenerateUniqueID(gameObject);
    }

    public bool CanInteract()
    {
        return !isInteracted;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        //Interact to get the cards/items
        CollectItem();

    }

    private void CollectItem()
    {
        CollectedItem(true);

        if (itemPrefab)
        {

            //pop-up window 

        }
    }

    public void CollectedItem(bool collected)
        {
            if (isInteracted == collected)
            {
                GetComponent<SpriteRenderer>().sprite = interactedSprite;
            }
        }
    }
