using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private TMP_Text _endGameText;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
        _player.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
        _player.PlayerDied -= OnPlayerDied;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }

    private void OnPlayerDied(int money)
    {
        _endGameText.text = "You earned - " + money;
    }
}
