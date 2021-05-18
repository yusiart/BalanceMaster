using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    private void Update()
    {
       transform.position += new Vector3(0, 0, -Speed * Time.deltaTime);
    }
}
