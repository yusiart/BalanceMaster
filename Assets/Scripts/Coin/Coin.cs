﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinPrice;
    
    public int GetReward()
    {
        return _coinPrice;
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
