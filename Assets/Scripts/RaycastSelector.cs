using System.Collections;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    // Config
    [SerializeField] private float interactionTime = 1.5f;
    [SerializeField] private float maxRayDistance = 150;


    private bool isInteracting = false;
    private GameObject currentTarget = null;
    private IInteractable interactable = null;
    private Coroutine interactionCoroutine = null;

    private void Update()
    {
        RaycastHit hit = FireRay();
        bool noTarget = !hit.transform;

        if (noTarget)
        {
            CancelInteraction();
            currentTarget = null;
            return;
        }

        var newTarget = hit.transform.gameObject;
        bool targetNotChanged = newTarget == currentTarget;
        if (targetNotChanged) return;

        CancelInteraction();
        currentTarget = newTarget;
        Debug.Log($"Current Target: {currentTarget.name}");
        interactable = currentTarget.GetComponent<IInteractable>();
        bool isNotInteractable = interactable == null;
        if (isNotInteractable) return;

        interactionCoroutine = StartCoroutine(Interact());
    }

    private IEnumerator Interact()
    {
        interactable.Highlight();
        isInteracting = true;
        Debug.Log("Waiting for interaction time...");
        yield return new WaitForSeconds(interactionTime);
        interactable.Interact(this);
        Debug.Log("Interaction Executed");
    }

    private void CancelInteraction()
    {
        if (!isInteracting) return;
        interactable.CancelHighlight();
        StopCoroutine(interactionCoroutine);
        isInteracting = false;
        Debug.Log("Interaction Cancelled");
    }

    private RaycastHit FireRay()
    {
        Debug.DrawRay(transform.position, transform.forward * maxRayDistance, Color.green);
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxRayDistance);
        return hit;
    }
}
