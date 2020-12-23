using UnityEngine;
using VisitaVirtual.Control;

namespace VisitaVirtual.Interaction
{
    public class Location : Interactable
    {
        // Cached References
        private Teleporter playerTeleporter;

        private void Awake()
        {
            playerTeleporter = FindObjectOfType<Teleporter>();
        }

        public override void Interact()
        {
            if (locationMarkers == null) return;
            var destination = FindClosestLocationMarker();
            playerTeleporter.TeleportToPosition(destination);
            base.Interact();
        }

        private Transform FindClosestLocationMarker()
        {
            var destination = locationMarkers[0].transform;
            var playerPosition = playerTeleporter.transform.position;
            foreach (var marker in locationMarkers)
            {
                if (Vector3.Distance(playerPosition, marker.transform.position) >
                    Vector3.Distance(playerPosition, destination.position)) continue;

                destination = marker.transform;
            }
            return destination;
        }
    }
}
