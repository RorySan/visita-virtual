using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PointOfInterest : MonoBehaviour, IInteractable
{
    // config
    [SerializeField] private float interactionTime = 1.5f;
    [SerializeField] private Outline targetOutline;
    [SerializeField] protected LocationMarker targetPosition;
    [SerializeField] private UnityEvent onInteraction;
    

    private bool isInteracting;

    private Coroutine interactionCoroutine = null;

    private void Start()
    {
        targetOutline.enabled = false;
    }

    public virtual void Interact()
    {
        if (targetPosition.HasPlayer) return;
        interactionCoroutine = StartCoroutine(InitiateInteraction());
    }

    public void CancelInteraction()
    {
        if (!isInteracting) return;
        StopCoroutine(interactionCoroutine);
        CancelHighlight();
        isInteracting = false;
        Debug.Log("Interaction Cancelled");
    }


    private IEnumerator InitiateInteraction()
    {
        Highlight();
        isInteracting = true;
        Debug.Log("Waiting for interaction time...");
        yield return new WaitForSeconds(interactionTime);
        //interactable.Interact(this);
        onInteraction.Invoke();
        Debug.Log("Interaction Executed");
    }
    
    private void Highlight()
    {
        targetOutline.enabled = true;
    }

    private void CancelHighlight()
    {
        targetOutline.enabled = false;
    }

}
