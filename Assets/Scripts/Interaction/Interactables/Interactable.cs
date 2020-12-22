using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace VisitaVirtual.Interaction
{
    public class Interactable : MonoBehaviour
    {
        // Config Options
            // Determines if the interaction can be activated from outside the location marker
        [SerializeField] private bool requiresPlayerAtLocationMarker;
        
        // Cached References
            // Locations available for this interaction
        [SerializeField] protected List<LocationMarker> locationMarkers;
            // Highlights interactable objects
        private IHighlighter myHighlighter;
        
        // Events
        public OnInteraction onInteraction;
        [System.Serializable]
        public class OnInteraction : UnityEvent<Interactable>
        {
        }

        protected virtual void Start()
        {
            myHighlighter = GetComponent<IHighlighter>();
            DisableHighlight(); 
        }

        public virtual void Interact()
        {
            onInteraction.Invoke(this);
        }
        
        public void EnableHighlight()
        {
            myHighlighter?.Highlight();
        }

        public void DisableHighlight()
        {
            myHighlighter?.CancelHighlight();
        }

        public bool PlayerAtCorrectLocation()
        {
            bool isPlayerAtLocationMarker = locationMarkers.FirstOrDefault(marker => 
                marker.HasPlayer);
            return requiresPlayerAtLocationMarker == isPlayerAtLocationMarker;
        }
    }
}