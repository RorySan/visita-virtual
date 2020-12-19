using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisitaVirtual.Interaction;

namespace VisitaVirtual.Control
{
    public class RaycastSelector : MonoBehaviour
    {
        // Config Options
        [SerializeField] private float interactionTime = 1.5f;
        [SerializeField] private float maxRayDistance = 150;

        // Cached References
        private List<Interactable> interactables;
        
        // Support Variables
        private GameObject currentTarget;
        private Interactable currentInteraction;
        private bool isInteracting;
        private Coroutine interactionCoroutine;

        private void Start()
        {
            CacheReferences();
        }

        private void FixedUpdate()
        {
            var raycastHit = FireRay();
            if (FindsNoTarget(raycastHit)) return;
            if (TargetIsNotNew(raycastHit, out var newTarget)) return;
            ManageNewTarget(newTarget);
        }

        private bool FindsNoTarget(RaycastHit hit)
        {
            if (hit.transform) return false;
            CancelCurrentInteraction();
            currentTarget = null;
            return true;
        }

        private bool TargetIsNotNew(RaycastHit hit, out GameObject newTarget)
        {
            newTarget = hit.transform.gameObject;
            return newTarget == currentTarget;
        }

        private void ManageNewTarget(GameObject newTarget)
        {
            CancelCurrentInteraction();
            currentTarget = newTarget;
            if (TargetInteractable()) 
                ExecuteInteraction();
        }
        private bool TargetInteractable()
        {
            currentInteraction = interactables.FirstOrDefault(interactable =>
                interactable.gameObject == currentTarget);
            return currentInteraction && currentInteraction.PlayerAtCorrectLocation();
        }
        private void ExecuteInteraction()
        {
            interactionCoroutine = StartCoroutine(Interact());
        }

        private IEnumerator Interact()
        {
            currentInteraction.EnableHighlight();
            isInteracting = true;
            yield return new WaitForSeconds(interactionTime);
            currentInteraction.Interact();
            CancelCurrentInteraction();
        }
        
        private void CancelCurrentInteraction()
        {
            if (!isInteracting) return;
            StopCoroutine(interactionCoroutine);
            currentInteraction.DisableHighlight();
            isInteracting = false;
        }

        private RaycastHit FireRay()
        {
            Physics.Raycast(transform.position, transform.forward, out var hit, maxRayDistance);
            return hit;
        }
        
        private void CacheReferences()
        {
            interactables = FindObjectsOfType<Interactable>().ToList();
        }
    }
}