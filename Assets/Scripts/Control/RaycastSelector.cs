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
        [SerializeField] private List<Interactable> interactables;
        
        // Support Fields
        private GameObject currentTarget;
        private Interactable currentInteraction;
        private Coroutine interactionCoroutine;
        private bool isInteracting;

        private void Start()
        {
            interactables = FindObjectsOfType<Interactable>().ToList();
        }

        private void FixedUpdate()
        {
            if (RaycastFindsTarget(out var target) && 
                TargetIsNew(target))
                ManageNewTarget(target);
        }

        private bool RaycastFindsTarget(out GameObject target)
        {
            if (RaycastHits(out var hit))
            {
                target = hit.transform.gameObject;
                return true;
            }
            CancelCurrentInteraction();
            target = currentTarget = null;
            return false;
        }
        
        private bool RaycastHits(out RaycastHit hit)
        {
            return Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance);
        }
        
        private bool TargetIsNew(GameObject target)
        {
            return target != currentTarget;
        }

        private void ManageNewTarget(GameObject newTarget)
        {
            CancelCurrentInteraction();
            currentTarget = newTarget;
            if (TargetIsInteractable()) 
                ExecuteInteraction();
        }
        private bool TargetIsInteractable()
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
    }
}