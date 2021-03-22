using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
   [SerializeField] private GameObject _panel;

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out Player player))
      {
         player.Die();
         _panel.SetActive(true);
      }
   }
}
