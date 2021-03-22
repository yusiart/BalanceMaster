using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinPrice;
    [SerializeField] private ParticleSystem _collectCoin;

    public int GetReward()
    {
        Instantiate(_collectCoin, transform.position, Quaternion.identity);
        return _coinPrice;
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
