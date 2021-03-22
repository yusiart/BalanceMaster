using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingSpawner : ObjectPool
{
    [SerializeField] private List<GameObject> _buildingTemplates;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private int _generatedBuildingCount;

    private float _distanceBetweenBuilding;
    private float _timer;

    private void Start()
    {
        foreach (var building in _buildingTemplates)
        {
            Initialize(building);
        }

        GenerateBuildings();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeToSpawn)
        {
            InstantiateBuildings();
            _timer = 0f;
        }
    }

    private void SetActiveBuilding(GameObject building, Transform spawnPoint)
    {
        building.gameObject.SetActive(true);
        building.transform.position = spawnPoint.transform.position;
    }

    private void GenerateBuildings()
    {
        for (int i = 0; i < _generatedBuildingCount; i++)
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                if (TryGetRandomBuilding(out GameObject building))
                {
                    SetActiveBuilding(building, spawnPoint);
                    building.transform.position -= new Vector3(0, 0, _distanceBetweenBuilding);
                }
            }

            _distanceBetweenBuilding += 15;
        }
    }
    
    private void InstantiateBuildings()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            if (TryGetRandomBuilding(out GameObject building))
            {
                SetActiveBuilding(building, spawnPoint);
            }
        }
    }

    private bool TryGetRandomBuilding(out GameObject build)
    {
        int randomBuild = Random.Range(0, _pool.Count);

        if (_pool[randomBuild].gameObject.activeSelf == false)
        {
            build = _pool[randomBuild];
            return build != null;
        }

        build = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return build != null;
    }
}
