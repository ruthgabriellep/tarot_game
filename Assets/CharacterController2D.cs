using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
     [SerializeField] 
     public float moveSpeed = 5f;
     public float sprintSpeed = 7f;

     public Rigidbody2D rigidbody;
     private Vector2 moveVector;
     private bool sprintRequested = false;
     

     void Start()
     {
          rigidbody = GetComponent<Rigidbody2D>();
     }

     private void FixedUpdate()
     {
          rigidbody.linearVelocityX = moveVector.x * moveSpeed;

          if (sprintRequested)
          {
               rigidbody.linearVelocityX = sprintSpeed;
          }
     }

     public void Sprint()
     {
          sprintRequested = true;
     }
}
