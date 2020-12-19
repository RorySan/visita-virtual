﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace VisitaVirtual.Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        // Config Options
            // Determines if the interaction can be activated from outside the location marker
        [SerializeField] private bool requiresPlayerAtLocationMarker;
      
        // Cached References
            // Outlines interactable objects
        [SerializeField] private Outline interactionOutline;
            // Locations available for this interaction
        [SerializeField] protected List<LocationMarker> locationMarkers;

        // Events
        public OnInteraction onInteraction;
        [System.Serializable]
        public class OnInteraction : UnityEvent<Interactable>
        {
        }

        protected virtual void Start()
        {
            DisableHighlight(); 
        }

        public virtual void Interact()
        {
            onInteraction.Invoke(this);
        }
        
        public void EnableHighlight()
        {
            interactionOutline.enabled = true;
        }

        public void DisableHighlight()
        {
            interactionOutline.enabled = false;
        }

        public bool PlayerAtCorrectLocation()
        {
            bool isPlayerAtLocationMarker = locationMarkers.FirstOrDefault(marker => 
                marker.HasPlayer);
            return requiresPlayerAtLocationMarker == isPlayerAtLocationMarker;
        }
    }
}