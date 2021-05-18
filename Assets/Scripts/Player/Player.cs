using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _fallForce;
    [SerializeField] private float _fallRadius;
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private GameObject _gameOverPanel;

    private Animator _animator;
    private int _money;
    private Rigidbody _rigidbody;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> PlayerDied;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
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
        else if(other.gameObject.TryGetComponent(out Bird bird))
        {
            Crash();
        }
    }

    private void Crash()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        
        _animator.SetBool("IsCrushed", true);

        Instantiate(_collisionEffect, transform);
        _rigidbody.isKinematic = false;
        _rigidbody.AddExplosionForce(_fallForce, transform.position + new Vector3(0, -1, 1), _fallRadius);

        StartCoroutine(nameof(Die));
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        
        _gameOverPanel.SetActive(true);
        PlayerDied?.Invoke(_money);
    }
}
