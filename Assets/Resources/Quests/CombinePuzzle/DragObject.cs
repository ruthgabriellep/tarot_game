using UnityEngine;

public class DragObject : MonoBehaviour
{

    [Header("Objectives")] [SerializeField] private GameObject objectives;
    
    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    private void Start()
    {
        objectives.SetActive(true);
    }

    private void onMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameObjectName;
        string collisionGameObjectName;

        thisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameObjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if (mouseButtonReleased && thisGameObjectName == "Wood" && thisGameObjectName == collisionGameObjectName)
        {
            Instantiate(Resources.Load("Boat_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            objectives.SetActive(false);
        }
    }
}
