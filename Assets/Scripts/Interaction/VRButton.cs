using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VisitaVirtual.Interaction
{
    public class VRButton : MonoBehaviour, IInteractable
    {
        // Config Options
        public UnityEvent onInteraction;
        
        // Cached References
        private Image buttonImage;

        private void Awake()
        {
            buttonImage = GetComponent<Image>();
        }

        public void Interact() => onInteraction.Invoke();

        public void EnableHighlight() => buttonImage.color = Color.cyan;

        public void DisableHighlight() => buttonImage.color = Color.white;

        public bool IsAvailable() => true;
    }
}