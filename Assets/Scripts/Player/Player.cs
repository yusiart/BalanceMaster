using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Gravity))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _boanceRadius;
    [SerializeField] private ParticleSystem _particle;
    
    private int _money;
    private Rigidbody _rigidbody;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> PlayerDied;

    private void Start()
    {
        MoneyChanged?.Invoke(_money);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _money += coin.GetReward();
            coin.Destroy();
            MoneyChanged?.Invoke(_money);
        }
        else if(other.gameObject.TryGetComponent(out Bird bird))
        {
            Smash();
        }
    }

    public void Die()
    {
        PlayerDied?.Invoke(_money);
    }

    public void Smash()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;

        Instantiate(_particle, transform);
        _rigidbody.isKinematic = false;
        _rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _boanceRadius);
        
    }
}
