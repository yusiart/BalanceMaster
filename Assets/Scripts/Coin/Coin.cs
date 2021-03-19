using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinPrice;
    [SerializeField] private ParticleSystem _collectEffect;

    public int GetReward()
    {
        return _coinPrice;
    }

    public void Destroy()
    {
        _collectEffect.Play();
        gameObject.SetActive(false);
    }
}
