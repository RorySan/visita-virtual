using UnityEngine;

namespace VisitaVirtual.Interaction
{
    public class ClickSelector : Selector
    {
        protected override void ExecuteInteraction()
        {
            if (Input.GetMouseButtonUp(0) && CurrentInteractable)
            {
                CurrentInteractable.Interact();
                CurrentInteractable.DisableHighlight();
            }
        }
    }
}