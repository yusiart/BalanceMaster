using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : ObjectPool
{
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _timer;

    private void Start()
    {
        Initialize(_coinTemplate);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeToSpawn)
        {
            if (TryToGetObject(out GameObject coin))
            {
                SetActiveCoin(coin);
                _timer = 0f;
            }
        }
    }

    private void SetActiveCoin(GameObject coin)
    {
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Count);
        coin.gameObject.SetActive(true);
        coin.transform.position = _spawnPoints[randomSpawnPoint].transform.position;
    }
}
