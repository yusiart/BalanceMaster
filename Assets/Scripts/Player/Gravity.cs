using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    [SerializeField] private Transform _ropeTransform;

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.FromToRotation(-transform.up, _ropeTransform.position - transform.position);
        transform.rotation = rotation * transform.rotation;
    }
}