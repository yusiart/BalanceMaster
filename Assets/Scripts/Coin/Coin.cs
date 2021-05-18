using System.Collections;
using UnityEngine;

public class Coin : Object
{
    [SerializeField] private int _coinPrice;
    [SerializeField] private ParticleSystem _collectCoin;

    public int GetReward()
    {
        Instantiate(_collectCoin, transform.position, Quaternion.identity);

        return _coinPrice;
    }
}
