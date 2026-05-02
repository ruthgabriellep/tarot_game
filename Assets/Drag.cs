using UnityEngine;

public class Drag : MonoBehaviour
{
    private Camera mainCam;
    private bool isDragging = false;
    private bool isRotating = false;
    private Vector3 offset;
    private float rotationSpeed = 200f; // Degrees per second

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        HandleDragging();
        HandleRotation();
    }

    void HandleDragging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.transform == transform)
            {
                isDragging = true;
                offset = transform.position - (Vector3)mousePos;
            }
        }
        
        if (isDragging && Input.GetMouseButton(0))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3 (mousePos.x + offset.x, transform.position.y, transform.position.z);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void HandleRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.transform == transform)
            {
                isRotating = true;
            }
        }
        
        if (isRotating && Input.GetMouseButton(1))
        {
            float rotationInput = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime);
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
    }
}
    
    // public LayerMask m_DragLayers;
    //
    // [Range(0.0f, 100.0f)]
    // public float m_Damping = 1.0f;
    //
    // [Range(0.0f, 100.0f)]
    // public float m_Frequency = 5.0f;
    //
    // public bool m_DrawDragLine = true;
    // public Color m_Color = Color.cyan;
    //
    // private TargetJoint2D m_TargetJoint;
    //
    // void Update()
    // {
    //     var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         var collider = Physics2D.OverlapPoint(worldPos, m_DragLayers);
    //         if (!collider)
    //             return;
    //
    //         var body = collider.attachedRigidbody;
    //         if (!body)
    //             return;
    //
    //         m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D>();
    //         m_TargetJoint.dampingRatio = m_Damping;
    //         m_TargetJoint.frequency = m_Frequency;
    //
    //         m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(worldPos);
    //
    //     }
    //     else if (Input.GetMouseButtonUp(0))
    //     {
    //         Destroy(m_TargetJoint);
    //         m_TargetJoint = null;
    //         return;
    //     }
    //
    //     if (m_TargetJoint)
    //     {
    //         m_TargetJoint.target = worldPos;
    //         
    //         if(m_DrawDragLine)
    //             Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPos, m_Color);
    //     }
    // }
