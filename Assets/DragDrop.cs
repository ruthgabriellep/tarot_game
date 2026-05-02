using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    // [SerializeField] private bool isDragging = false;
    //
    // void Update()
    // {
    //     if (isDragging)
    //     {
    //         transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     }
    // }
    //
    // private void OnMouseDown()
    // {
    //     isDragging = true;
    // }
    //
    // private void OnMouseUp()
    // {
    //     isDragging = false;
    // }
    
    Vector2 difference = Vector2.zero;

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}

