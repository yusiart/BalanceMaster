using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    [SerializeField] private Transform _rope;

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.FromToRotation(-transform.up, _rope.position - transform.position);
        transform.rotation = rotation * transform.rotation;
    }
}