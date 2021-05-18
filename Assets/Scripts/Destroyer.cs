using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Destroy();
        }
        else if (other.gameObject.TryGetComponent(out Building building))
        {
            building.Destroy();
        }
        else if (other.gameObject.TryGetComponent(out Car car))
        {
            car.Destroy();
        }
        else if (other.gameObject.TryGetComponent(out Bird bird))
        {
            bird.Destroy();
        }
    }
}
