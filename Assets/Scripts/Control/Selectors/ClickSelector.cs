using UnityEngine;
using VisitaVirtual.Control;

namespace VisitaVirtual.Interaction
{
    public class ClickSelector : Selector
    {
        protected override void ExecuteInteraction()
        {
            if (Input.GetMouseButtonUp(0) && currentInteractable)
            {
                currentInteractable.Interact();
                
                currentInteractable.DisableHighlight();
            }
        }
    }
}