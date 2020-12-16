using UnityEngine;
using UnityEngine.UI;

namespace VisitaVirtual.Interaction
{
    public class VRButton : Interactable
    {
        private Image buttonImage;

        private void Awake()
        {
            buttonImage = GetComponent<Image>();
        }

        public override void EnableHighlight()
        {
            buttonImage.color = Color.green;
        }

        public override void Interact()
        {
            onInteraction.Invoke(this);
        }

        public override void DisableHighlight()
        {
            buttonImage.color = Color.cyan;
        }
    }
}