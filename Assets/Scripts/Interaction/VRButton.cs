using UnityEngine;
using UnityEngine.UI;

namespace VisitaVirtual.Interaction
{
    public class VRButton : Interaction
    {
        private Image buttonImage;

        private void Awake()
        {
            buttonImage = GetComponent<Image>();
        }

        protected override void EnableHighlight()
        {
            buttonImage.color = Color.green;
        }

        public override void Interact()
        {
            interactionCoroutine = StartCoroutine(InitiateInteraction());
        }

        protected override void DisableHighlight()
        {
            buttonImage.color = Color.cyan;
        }
    }
}