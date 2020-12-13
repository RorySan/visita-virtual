using System.Collections;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    // TODO Cachear todos los interactuables de la escena en una lista al empezar
    // Config
    [SerializeField] private float maxRayDistance = 150;
    
    
    
    private GameObject currentTarget = null;
    private IInteractable interactableObject = null;

    private void Update()
    {
        RaycastHit hit = FireRay();
        bool noTarget = !hit.transform;
        if (noTarget)
        {
            interactableObject?.CancelInteraction();
            currentTarget = null;
            return;
        }

        var newTarget = hit.transform.gameObject;
        bool targetNotChanged = newTarget == currentTarget;
        if (targetNotChanged) return;

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
