using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
     [SerializeField] 
     public float moveSpeed = 5f;
     public float sprintSpeed = 5f;

     private Rigidbody2D _rigidbody;
     private Vector2 _moveVector;
     private bool _sprintRequested = false;

     void Start()
     {
          _rigidbody = GetComponent<Rigidbody2D>();
     }

     private void FixedUpdate()
     {
          _rigidbody.linearVelocityX = _moveVector.x * moveSpeed;

          if (_sprintRequested)
          {
                
          }
     }

     public void Move(Vector2 moveVector)
     {
          _moveVector = moveVector;
     }

     public void Sprint()
     {
          _sprintRequested = true;
     }
}
