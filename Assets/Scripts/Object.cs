using UnityEngine;

public class Object : MonoBehaviour
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}