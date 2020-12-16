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
            // Marks the location where the interaction takes place
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

        public virtual void Interact()
        {
            onInteraction.Invoke(this);
        }
        
        public virtual void EnableHighlight()
        {
            targetOutline.enabled = true;
        }

        public virtual void DisableHighlight()
        {
            targetOutline.enabled = false;
        }

        public bool IsInRange()
        {
           return requiresPlayerInRange == locationMarker.HasPlayer;
        }

        public string GetLocationName()
        {
            return locationMarker.GetLocationName();
        }
    }
}