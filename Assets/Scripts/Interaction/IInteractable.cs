
namespace VisitaVirtual.Interaction
{
    public interface IInteractable
    {
        bool IsAvailable();
        void Interact();
        void EnableHighlight();
        void DisableHighlight();
    }
}