using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdSpawner : ObjectPool
{
    private void Start()
    {
        InvokeRepeating("IncreasingComplexity", 15f,15f);
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > TimeToSpawn)
        {
            if (TryToGetObject(out GameObject bird))
            {
                SetActiveBird(bird);
                Timer = 0f;
            }
        }
    }

    private void IncreasingComplexity()
    {
        if (TimeToSpawn < 0.3f)
            return;
        
        TimeToSpawn -= 0.2f;
    }

    private void SetActiveBird(GameObject bird)
    {
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Count);
        bird.gameObject.SetActive(true);
        bird.transform.position = SpawnPoints[randomSpawnPoint].transform.position;
    }
}
