﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
   [SerializeField] private float _gravityStrengh;
   [SerializeField] private float _speed;

   private Rigidbody _rigidbody;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   private void Update()
   {
       GravityMove();
       
       if (Input.GetKey(KeyCode.A))
       {
           MoveLeft();
       }
       else if (Input.GetKey(KeyCode.D))
       {
           MoveRight();
       }

       Vector3 down = Vector3.Project(_rigidbody.velocity, Vector3.up);

       _rigidbody.velocity = down;
   }

   private void GravityMove()
   {
       if (transform.position.x < 0)
       {
           transform.Translate(Vector3.left * (_gravityStrengh * Time.deltaTime));
       }
       
       if (transform.position.x > 0)
       {
           transform.Translate(Vector3.right * (_gravityStrengh * Time.deltaTime));
       }
   }
   
   public void MoveRight()
   {
       transform.position = Vector3.Lerp(transform.position, Vector3.right, _speed * Time.deltaTime);
   }

   public void MoveLeft()
   {
       transform.position = Vector3.Lerp(transform.position, Vector3.left, _speed * Time.deltaTime);
   }
}
