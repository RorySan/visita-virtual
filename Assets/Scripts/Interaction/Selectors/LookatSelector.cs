using System.Collections;
using UnityEngine;

namespace VisitaVirtual.Interaction
{
    [RequireComponent(typeof(LookatCrosshair))]
    public class LookatSelector : Selector
    {
        // Config Options
        [SerializeField] private float interactionTime = 1.5f;
        
        // Cached Resources
        private LookatCrosshair crosshair;
        
        // Support Fields
        private Coroutine interactionCoroutine;

        private void Awake()
        {
            crosshair = GetComponent<LookatCrosshair>();
            crosshair.InteractionTime = interactionTime;
        }


        protected override void ExecuteInteraction()
        {
            if (!CurrentInteractable || InteractionExecuting()) return;
            interactionCoroutine = StartCoroutine(Interact());
        }

        private IEnumerator Interact()
        {
            crosshair.ActivateCrosshair();
            yield return new WaitForSeconds(interactionTime);
            CurrentInteractable.Interact();
            crosshair.DeactivateCrosshair();
            CurrentInteractable.DisableHighlight();
        }

        protected override void CancelCurrentInteraction()
        {
            if (!CurrentInteractable) return;
             
            CurrentInteractable.DisableHighlight();
            CurrentInteractable = null;
            if (interactionCoroutine == null) return;
            crosshair.DeactivateCrosshair();
            StopCoroutine(interactionCoroutine);
            interactionCoroutine = null;
        }
        
        private bool InteractionExecuting()
        {
            return interactionCoroutine != null;
        }
    }
}