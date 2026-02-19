using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
     [SerializeField] 
     public float moveSpeed = 5f;
     public float sprintSpeed = 7f;

     public Rigidbody2D rb;
     private Vector2 moveVector;
     private bool sprintRequested = false;
     

     void Start()
     {
          rb = GetComponent<Rigidbody2D>();
     }

     private void FixedUpdate()
     {
          rb.linearVelocityX = moveVector.x * moveSpeed;

          if (sprintRequested)
          {
               rb.linearVelocityX = sprintSpeed;
          }
     }

     public void Sprint()
     {
          sprintRequested = true;
     }
}
