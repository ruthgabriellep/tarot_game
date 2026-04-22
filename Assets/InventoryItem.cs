using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Transform _parentAfterDrag;
    //
    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     _parentAfterDrag = transform.parent;
    //     transform.SetParent(transform.root);
    //     transform.SetAsLastSibling();
    // }
    //
    // public void OnDrag(PointerEventData eventData)
    // {
    //     transform.position = Input.mousePosition;
    // }
    //
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     transform.SetParent(_parentAfterDrag);
    // }
    
    
    

    public Image image;
    private Transform originalParent;
    [SerializeField] private Transform dragLayer;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
    
        transform.SetParent(dragLayer);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
        image.raycastTarget = true;
    }

    // [Header("UI")] public Image image;
    //
    // [HideInInspector] public Transform parentAfterDrag;
    //
    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     image.raycastTarget = false;
    //     parentAfterDrag = transform.parent;
    //     transform.SetParent(transform.root);
    // }
    //
    // public void OnDrag(PointerEventData eventData)
    // {
    //     transform.position = Input.mousePosition;
    // }
    //
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     image.raycastTarget = true;
    //     transform.SetParent(parentAfterDrag);
    // }
}
