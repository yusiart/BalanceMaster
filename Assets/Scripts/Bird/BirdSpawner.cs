using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : ObjectPool
{
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeToSpawn)
        {
            if (TryToGetObject(out GameObject bird))
            {
                SetActiveBird(bird);
                _timer = 0f;
            }
        }
    }

    private void SetActiveBird(GameObject bird)
    {
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Count);
        bird.gameObject.SetActive(true);
        bird.transform.position = _spawnPoints[randomSpawnPoint].transform.position;
    }
}
