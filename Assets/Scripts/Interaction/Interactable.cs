using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace VisitaVirtual.Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        // Config Options
            // Determines if the interaction can be activated from outside the location marker
        [SerializeField] private bool requiresPlayerAtLocationMarker;
      
        // Cached References
            // Outlines objects to indicate they are interactable
        [SerializeField] private Outline interactionOutline;
            // Marks the location for this interaction
        [SerializeField] private LocationMarker locationMarker;

        // Events
        public OnInteraction onInteraction;
        
        // Support Variables
        private bool isPlayerAtLocationMarker;
        
        
        [System.Serializable]
        public class OnInteraction : UnityEvent<Interactable>
        {
        }

        private void Start()
        {
            DisableHighlight(); 
        }

        public void Interact()
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
            return requiresPlayerAtLocationMarker == locationMarker.HasPlayer;
        }
    }
}