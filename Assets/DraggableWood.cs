using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableWood : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Vector2 _originalPosition;

    [SerializeField] private BoatRepair boatRepair; // drag your BoatRepair object here in Inspector
    [SerializeField] private float snapDistance = 150f; // how close to the boat before snapping

    private Camera _mainCamera;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _mainCamera = Camera.main;
        _originalPosition = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // allow raycast to pass through while dragging so we can detect the boat
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move the UI element with the mouse
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        
        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // check if close enough to the broken boat
        if (boatRepair != null)
        {
            float distance = Vector2.Distance(mouseWorldPos, boatRepair.transform.position);
            
            Debug.Log($"Drop distance to boat: {distance}");

            if (distance <= snapDistance)
            {
                boatRepair.RepairBoat();
                gameObject.SetActive(false); // hide wood UI after successful repair
                return;
            }
        }
        
        _rectTransform.anchoredPosition = _originalPosition;
    }

    public void ResetPosition()
    {
        _rectTransform.anchoredPosition = _originalPosition;
    }
}
