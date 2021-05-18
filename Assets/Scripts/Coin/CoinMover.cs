

using UnityEngine;

public class CoinMover : ObjectMover
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
