using System;
using UnityEngine;

namespace VisitaVirtual.Interaction
{
    public class LocationMarker : MonoBehaviour
    {
        // Flags if a the player is at the LocationMarker
        public bool HasPlayer { get; private set; }

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
            //Marks position with a gizmo
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}