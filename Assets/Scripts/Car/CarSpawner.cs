using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : ObjectPool
{
    [SerializeField] private List<GameObject>  _carTemplate;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _timer;

    private void Start()
    {
        foreach (var car in _carTemplate)
        {
            Initialize(car);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeToSpawn)
        {
            if (TryToGetObject(out GameObject car))
            {
                SetActiveCoin(car);
                _timer = 0f;
            }
        }
    }

    private void SetActiveCoin(GameObject car)
    {
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Count);
        car.gameObject.SetActive(true);
        car.transform.position = _spawnPoints[randomSpawnPoint].transform.position;
    }
}
