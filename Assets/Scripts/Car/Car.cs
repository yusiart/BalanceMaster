using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMover))]
public class Car : MonoBehaviour
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
