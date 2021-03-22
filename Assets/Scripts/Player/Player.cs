using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Gravity))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private int _money;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> PlayerDied; 

    private void Start()
    {
        MoneyChanged?.Invoke(_money);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _money += coin.GetReward();
            coin.Destroy();
            MoneyChanged?.Invoke(_money);
        }
    }

    public void Die()
    {
        PlayerDied?.Invoke(_money);
    }
}
