using System.Linq;
using UnityEngine;

public class BuildingSpawner : ObjectPool
{
    [SerializeField] private int _generatedBuildingCount;
    [SerializeField] private float _buildingOffset;

    private float _distanceBetweenBuilding;

    private void Start()
    {
        GenerateBuildings();
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > TimeToSpawn)
        {
            InstantiateBuildings();
            Timer = 0f;
        }
    }

    private void SetActiveBuilding(GameObject building, Transform spawnPoint)
    {
        building.gameObject.SetActive(true);
        building.transform.position = spawnPoint.transform.position;
        building.transform.rotation = spawnPoint.transform.rotation;
    }

    private void GenerateBuildings()
    {
        for (int i = 0; i < _generatedBuildingCount; i++)
        {
            foreach (var spawnPoint in SpawnPoints)
            {
                if (TryGetBuilding(out GameObject building))
                {
                    SetActiveBuilding(building, spawnPoint);
                    building.transform.position -= new Vector3(0, 0, _distanceBetweenBuilding);
                }
            }

            _distanceBetweenBuilding += _buildingOffset;
        }
    }
    
    private void InstantiateBuildings()
    {
        foreach (var spawnPoint in SpawnPoints)
        {
            if (TryGetBuilding(out GameObject building))
            {
                SetActiveBuilding(building, spawnPoint);
            }
        }
    }

    private bool TryGetBuilding(out GameObject build)
    {
        if (TryGetRandomBuilding(out GameObject building))
        {
            build = building;
        }
        else
        {
            build = Pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        }
           
        return build != null;
    }

    private bool TryGetRandomBuilding(out GameObject building)
    {
        for (int i = 0; i < 3; i++)
        {
           int randomBuild = Random.Range(0, Pool.Count);

           if (Pool[randomBuild].gameObject.activeSelf == false)
           {
               building = Pool[randomBuild];
               return true;
           }
        }

        building = null;
        return false;
    }
}
