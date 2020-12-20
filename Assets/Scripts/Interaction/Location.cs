using System;
using UnityEngine;
using VisitaVirtual.Movement;

namespace VisitaVirtual.Interaction
{
    public class Location : Interactable
    {
        Mover playerMover;

        private void Awake()
        {
            playerMover = FindObjectOfType<Mover>();
        }
        
        public override void Interact()
        {
            if (locationMarkers == null) return;
            var destination = FindClosestLocationMarker();
            playerMover.MoveToPosition(destination);
            base.Interact();
        }

        private Transform FindClosestLocationMarker()
        {
            var destination = locationMarkers[0].transform;
            if (locationMarkers.Count == 1) return destination;
            
            var playerPosition = playerMover.transform.position;
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
