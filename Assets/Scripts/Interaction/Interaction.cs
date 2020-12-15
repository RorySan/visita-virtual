using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace VisitaVirtual.Interaction
{
    public class Interaction : MonoBehaviour, IInteractable
    {
        // Config Options
        [SerializeField] private float interactionTime = 1.5f;
        [SerializeField] private bool playerRequiredAtLocation;
      
        // Cached References
        [SerializeField] private Outline targetOutline;
        [SerializeField] private LocationMarker locationMarker;

        // Events
        public OnInteraction onInteraction;
        
        // Support Variables
        private bool isInteracting;
        private bool hasPlayer;
        protected Coroutine interactionCoroutine;
        
        [System.Serializable]
        public class OnInteraction : UnityEvent<Interaction>
        {
        }

        private void Start()
        {
            DisableHighlight(); 
        }

        public virtual void Interact()
        {
            if (locationMarker.HasPlayer != playerRequiredAtLocation) return;
            interactionCoroutine = StartCoroutine(InitiateInteraction());
        }

        public LocationMarker GetLocationMarker()
        {
            return locationMarker;
        }

        public void CancelInteraction()
        {
            if (!isInteracting) return;
            StopCoroutine(interactionCoroutine);
            DisableHighlight();
            isInteracting = false;
        }
        protected virtual void EnableHighlight()
        {
            targetOutline.enabled = true;
        }

        protected virtual void DisableHighlight()
        {
            targetOutline.enabled = false;
        }

        protected IEnumerator InitiateInteraction()
        {
            EnableHighlight();
            isInteracting = true;
            yield return new WaitForSeconds(interactionTime);
            
            onInteraction.Invoke(this);
            DisableHighlight();
        }
    }
}