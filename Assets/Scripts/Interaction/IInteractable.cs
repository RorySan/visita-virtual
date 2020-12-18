
namespace VisitaVirtual.Interaction
{
    public interface IInteractable
    {
        bool PlayerAtCorrectLocation();
        void Interact();
        void EnableHighlight();
        void DisableHighlight();
    }
}