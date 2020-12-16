
namespace VisitaVirtual.Interaction
{
    public interface IInteractable
    {
        bool IsInRange();
        void Interact();
        void EnableHighlight();
        void DisableHighlight();
    }
}