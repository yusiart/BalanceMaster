using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _buttonSpeed;

   private Rigidbody _rigidbody;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
       if (transform.position.x < 0)
       {
           transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
       }

       if (transform.position.x > 0)
       {
           transform.Translate(_speed * Time.deltaTime, 0, 0);
       }
       
       Vector3 down = Vector3.Project(_rigidbody.velocity, Vector3.up);

       _rigidbody.velocity = down;
   }

   public void MoveRight()
   {
       transform.Translate(_buttonSpeed * Time.deltaTime, 0, 0);
   }

   public void MoveLeft()
   {
       transform.Translate(_buttonSpeed * Time.deltaTime * -1, 0, 0);
   }
}
