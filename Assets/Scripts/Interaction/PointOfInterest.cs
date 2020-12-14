using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace VisitaVirtual.Interaction
{
    public class PointOfInterest : MonoBehaviour, IInteractable
    {
        // config
        [SerializeField] private float interactionTime = 1.5f;
        [SerializeField] private Outline targetOutline;
        [SerializeField] private LocationMarker locationMarker;
        [SerializeField] private bool playerRequiredAtLocation;
      
        public OnInteraction onInteraction;
        private bool isInteracting;
        protected Coroutine interactionCoroutine;
        
        [System.Serializable]
        public class OnInteraction : UnityEvent<PointOfInterest>
        {
        }

        private void Start()
        {
            CancelHighlight();
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
            CancelHighlight();
            isInteracting = false;
            Debug.Log("Interaction Cancelled");
        }
        protected virtual void Highlight()
        {
            targetOutline.enabled = true;
        }

        protected virtual void CancelHighlight()
        {
            targetOutline.enabled = false;
        }

        protected IEnumerator InitiateInteraction()
        {
            Highlight();
            isInteracting = true;
            Debug.Log("Waiting for interaction time...");
            yield return new WaitForSeconds(interactionTime);
            onInteraction.Invoke(this);
            CancelHighlight();
            Debug.Log("Interaction Executed");
        }
    }
}