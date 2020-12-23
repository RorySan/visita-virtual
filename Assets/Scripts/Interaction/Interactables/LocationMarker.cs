using UnityEngine;

namespace VisitaVirtual.Interaction
{
    public class LocationMarker : MonoBehaviour
    {
        // Flags if the player is at the LocationMarker
        public bool HasPlayer { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            HasPlayer = true;
        }

        private void OnTriggerExit(Collider other)
        {
            HasPlayer = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}
