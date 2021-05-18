using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : ObjectPool
{
    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > TimeToSpawn)
        {
            if (TryToGetObject(out GameObject coin))
            {
                SetActiveCoin(coin);
                Timer = 0f;
            }
        }
    }

    private void SetActiveCoin(GameObject coin)
    {
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Count);
        coin.gameObject.SetActive(true);
        coin.transform.position = SpawnPoints[randomSpawnPoint].transform.position;
    }
}
