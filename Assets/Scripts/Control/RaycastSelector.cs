using System.Collections;
using UnityEngine;
using VisitaVirtual.Interaction;

namespace VisitaVirtual.Control
{
    public class RaycastSelector : MonoBehaviour
    {
        // TODO Cachear todos los interactuables de la escena en una lista al empezar
        //private List<IInteractable> interactables;
       
        // Config Options
        [SerializeField] private float interactionTime = 1.5f;
        [SerializeField] private float maxRayDistance = 150;

        // Support Variables
        private GameObject currentTarget;
        private IInteractable interactableObject;
        private bool isInteracting;
        private Coroutine interactionCoroutine;
        
        private void FixedUpdate()
        {
            var raycastHit = FireRay();
            if (!FindsTarget(raycastHit)) return;
            if (TargetNotChanged(raycastHit, out var newTarget)) return;

            InteractWithNewTarget(newTarget);
        }

        private bool FindsTarget(RaycastHit hit)
        {
            if (hit.transform) return true;
            CancelInteraction();
            currentTarget = null;
            return false;
        }

        private bool TargetNotChanged(RaycastHit hit, out GameObject newTarget)
        {
            newTarget = hit.transform.gameObject;
            return newTarget == currentTarget;
        }

        private void InteractWithNewTarget(GameObject newTarget)
        {
            CancelInteraction();
            currentTarget = newTarget;
            interactableObject = currentTarget.GetComponent<IInteractable>();
            if (interactableObject == null || !interactableObject.PlayerAtCorrectLocation()) return;
            
            interactionCoroutine = StartCoroutine(InitiateInteraction());
        }
        
        private IEnumerator InitiateInteraction()
        {
            interactableObject.EnableHighlight();
            isInteracting = true;
            yield return new WaitForSeconds(interactionTime);
            interactableObject.Interact();
            CancelInteraction();
        }
        
        private void CancelInteraction()
        {
            if (!isInteracting) return;
            StopCoroutine(interactionCoroutine);
            interactableObject.DisableHighlight();
            isInteracting = false;
        }

        private RaycastHit FireRay()
        {
            Physics.Raycast(transform.position, transform.forward, out var hit, maxRayDistance);
            return hit;
        }
    }
}