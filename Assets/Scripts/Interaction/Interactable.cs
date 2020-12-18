using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace VisitaVirtual.Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        // Config Options
            // Determines if the interaction can be activated from outside the location marker
        [SerializeField] private bool requiresPlayerInRange;
      
        // Cached References
            // Outlines objects to indicate they are interactable
        [SerializeField] private Outline targetOutline;
            // Marks the location for this interaction
        [SerializeField] private LocationMarker locationMarker;

        // Events
        public OnInteraction onInteraction;
        
        // Support Variables
        private bool hasPlayer;
        
        
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
            targetOutline.enabled = true;
        }

        public void DisableHighlight()
        {
            targetOutline.enabled = false;
        }

        public bool IsAvailable()
        {
            if (!locationMarker) return true;
           return requiresPlayerInRange == locationMarker.HasPlayer;
        }
    }
}