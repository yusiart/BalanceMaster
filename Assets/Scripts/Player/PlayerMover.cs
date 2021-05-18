using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform [] _playerPositions = new Transform[4];
    [SerializeField] private float _jumpForce;
    
   private Vector2 _direction;
   private Vector2 _startPosition;
   private bool _directionChosen;
   private Transform _target;
   private int _currentPosition = 1;
   private Animator _animator;
   private Rigidbody _rigidbody;
   private bool _isGrounded;

   private void Start()
   {
       _animator = GetComponent<Animator>();
       _rigidbody = GetComponent<Rigidbody>();
       _target = _playerPositions[_currentPosition];
   }

   private void Update()
   {
       if (Math.Abs(transform.position.x - _target.transform.position.x) > 0.05f)
       {
           Move();
       }

       if (Input.GetKeyDown(KeyCode.A) && _isGrounded)
       {
           SetTarget(new Vector2(-1, -1));
       }
       
       if (Input.GetKeyDown(KeyCode.D) && _isGrounded)
       {
           SetTarget(new Vector2(1, 1));
       }
       
       if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
       {
           Jump();
       }
       

#if UNITY_ANDROID
       if (Input.touchCount > 0)
       {
           Touch touch = Input.GetTouch(0);
           
           switch (touch.phase)
           {
               case TouchPhase.Began:
                   _startPosition = touch.position;
                   _directionChosen = false;
                   break;
               
               case TouchPhase.Moved:
                   _direction = touch.position - _startPosition;
                   break;
               
               case TouchPhase.Ended:
                   _directionChosen = true;
                   break;
           }
       }
       if (_directionChosen)
       {
           if (_direction.y > 50f)
           {
               Jump();
           }
           else
           {
               SetTarget(_direction);
           }
           
           _directionChosen = false;
       }
#endif
   }

   private void SetTarget(Vector2 direction)
   {
       if (direction.x >= 0)
       {
           if (_currentPosition + 1 < 4)
           {
               _animator.SetTrigger("IsMoving");
               _target = _playerPositions[++_currentPosition];
           }
       }
       else
       {
           if (_currentPosition - 1 >= 0)
           {
               _animator.SetTrigger("IsMoving");
               _target = _playerPositions[--_currentPosition];
           }
       }
   }

   private void Move()
   {
       transform.position =
           Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
   }

   private void Jump()
   {
       _animator.SetTrigger("IsJumping");
       _rigidbody.AddForce(0, _jumpForce, 0);
   }

   private void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.TryGetComponent(out Ground ground))
       {
           _isGrounded = true;
       }
   }

   private void OnCollisionExit(Collision other)
   {
       if (other.gameObject.TryGetComponent(out Ground ground))
       {
           _isGrounded = false;
       }
   }
}
