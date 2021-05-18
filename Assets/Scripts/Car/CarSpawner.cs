using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : ObjectPool
{
    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > TimeToSpawn)
        {
            if (TryToGetObject(out GameObject car))
            {
                SetActiveCar(car);
                Timer = Random.Range(0, TimeToSpawn - 1);
            }
        }
    }

    private void SetActiveCar(GameObject car)
    {
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Count);
        car.gameObject.SetActive(true);
        car.transform.position = SpawnPoints[randomSpawnPoint].transform.position;
    }
}
