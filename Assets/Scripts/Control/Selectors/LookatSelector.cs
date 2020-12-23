using System.Collections;
using UnityEngine;

namespace VisitaVirtual.Control
{
    [RequireComponent(typeof(LookatCrosshair))]
    public class LookatSelector : Selector
    {
        // Config Options
        [SerializeField] private float interactionTime = 1.5f;
        
        // Support Fields
        private Coroutine interactionCoroutine;

        private LookatCrosshair crosshair;

        private void Awake()
        {
            crosshair = GetComponent<LookatCrosshair>();
            crosshair.InteractionTime = interactionTime;

        }


        protected override void ExecuteInteraction()
        {
            if (!currentInteractable || interactionCoroutine != null) return;

            interactionCoroutine = StartCoroutine(Interact());
        }

        private IEnumerator Interact()
        {
            crosshair.ActivateCrosshair();
            yield return new WaitForSeconds(interactionTime);
            currentInteractable.Interact();
            crosshair.DeactivateCrosshair();
            currentInteractable.DisableHighlight();
        }
        

        protected override void CancelCurrentInteraction()
        {
            if (!currentInteractable) return;
             
            currentInteractable.DisableHighlight();
            currentInteractable = null;
            if (interactionCoroutine == null) return;
            crosshair.DeactivateCrosshair();
            StopCoroutine(interactionCoroutine);
            interactionCoroutine = null;
        }
    }
}