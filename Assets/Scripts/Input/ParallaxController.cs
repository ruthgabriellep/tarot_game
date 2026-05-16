using System;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    // [SerializeField] private Transform cameraTransform;
    // [SerializeField] private float parallaxStrength = 0.5f;
    //
    // private float previousCameraX;
    //
    // void Start()
    // {
    //     previousCameraX = cameraTransform.position.x;
    // }
    //
    // void LateUpdate()
    // {
    //     float deltaX = cameraTransform.position.x - previousCameraX;
    //
    //     transform.position += new Vector3(deltaX * parallaxStrength, 0, 0);
    //
    //     previousCameraX = cameraTransform.position.x;
    // }

    private float startPos, length;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }

    }
}
