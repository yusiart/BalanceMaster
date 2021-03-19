using System;
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
       if (transform.position.x < 0)
       {
           transform.Translate(Vector3.left * (_gravityStrengh * Time.deltaTime));
       }
       
       if (transform.position.x > 0)
       {
           transform.Translate(Vector3.right * (_gravityStrengh * Time.deltaTime));
       }

       if (Input.GetKeyDown(KeyCode.A))
       {
            transform.position = Vector3.Lerp(transform.position, Vector3.left, _speed * Time.deltaTime);
           //transform.Translate(Vector3.left * (_speed * Time.fixedDeltaTime));
       }
       else if (Input.GetKeyDown(KeyCode.D))
       {
          transform.position = Vector3.Lerp(transform.position, Vector3.right, _speed * Time.deltaTime);
          //transform.Translate(Vector3.right * (_speed * Time.fixedDeltaTime));
       }

       Vector3 down = Vector3.Project(_rigidbody.velocity, Vector3.up);

       _rigidbody.velocity = down;
   }

   public void MoveRight()
   {
       transform.Translate(_speed * Time.deltaTime, 0, 0);
   }

   public void MoveLeft()
   {
       transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
   }
}
