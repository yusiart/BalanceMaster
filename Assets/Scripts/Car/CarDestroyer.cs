﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Car car))
        {
            car.Destroy();
        }
    }
}
