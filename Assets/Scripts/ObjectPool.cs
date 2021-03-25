using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _gameObjectTemplates;
    [SerializeField] protected float _timeToSpawn;
    [SerializeField] protected List<Transform> _spawnPoints;
    
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected float _timer;
    protected List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        foreach (var template in _gameObjectTemplates)
        {
            Initialize(template);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryToGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        
        return result != null;
    }
}
