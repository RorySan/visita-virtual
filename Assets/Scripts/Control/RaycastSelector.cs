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

        private GameObject currentTarget;
        private IInteractable interactableObject;
        private bool isInteracting;
        private Coroutine InteractionCoroutine;
        
        private void FixedUpdate()
        {
            RaycastHit hit = FireRay();
            if (!FindsTarget(hit)) return;
            if (TargetNotChanged(hit, out var newTarget)) return;

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
            Debug.Log($"Current Target: {currentTarget.name}");
            interactableObject = currentTarget.GetComponent<IInteractable>();
            if (interactableObject == null || !interactableObject.IsInRange()) return;
            
            InteractionCoroutine = StartCoroutine(InitiateInteraction());
        }
        
        private IEnumerator InitiateInteraction()
        {
            interactableObject.EnableHighlight();
            isInteracting = true;
            yield return new WaitForSeconds(interactionTime);
            Debug.Log("execute");
            interactableObject.Interact();
            CancelInteraction();
        }
        
        private void CancelInteraction()
        {
            if (!isInteracting) return;
            StopCoroutine(InteractionCoroutine);
            interactableObject.DisableHighlight();
            isInteracting = false;
        }

        private RaycastHit FireRay()
        {
            //Debug.DrawRay(transform.position, transform.forward * maxRayDistance, Color.green);
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxRayDistance);
            return hit;
        }
    }
}