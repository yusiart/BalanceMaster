
using System;
using Random = UnityEngine.Random;

public class BirdMover : ObjectMover
{
    private void Start()
    {
        int speedRange = Random.Range(1, 3);
        Speed += speedRange;
    }

    private void OnEnable()
    {
        Speed += 0.02f;
    }
}
