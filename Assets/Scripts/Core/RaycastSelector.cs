using UnityEngine;
using VisitaVirtual.Interaction;

namespace VisitaVirtual.Core
{
    public class RaycastSelector : MonoBehaviour
    {
        // TODO Cachear todos los interactuables de la escena en una lista al empezar
        // Config
        [SerializeField] private float maxRayDistance = 150;

        private GameObject currentTarget;
        private IInteractable interactableObject;

        private void FixedUpdate()
        {
            RaycastHit hit = FireRay();
            if (!FindTarget(hit)) return;
            if (TargetNotChanged(hit, out var newTarget)) return;

            InteractWithNewTarget(newTarget);
        }

        private bool FindTarget(RaycastHit hit)
        {
            if (hit.transform) return true;
            interactableObject?.CancelInteraction();
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
            interactableObject?.CancelInteraction();
            currentTarget = newTarget;
            Debug.Log($"Current Target: {currentTarget.name}");
            interactableObject = currentTarget.GetComponent<IInteractable>();
            interactableObject?.Interact();
        }

        private RaycastHit FireRay()
        {
            //Debug.DrawRay(transform.position, transform.forward * maxRayDistance, Color.green);
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxRayDistance);
            return hit;
        }
    }
}