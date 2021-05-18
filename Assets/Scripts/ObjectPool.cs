using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected List<GameObject> GameObjectTemplates;
    [SerializeField] protected float TimeToSpawn;
    [SerializeField] protected List<Transform> SpawnPoints;
    
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected float Timer;
    protected List<GameObject> Pool = new List<GameObject>();

    private void Awake()
    {
        foreach (var template in GameObjectTemplates)
        {
            Initialize(template);
        }
    }

    private void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            Pool.Add(spawned);
        }
    }

    protected bool TryToGetObject(out GameObject result)
    {
        result = Pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        
        return result != null;
    }
}
