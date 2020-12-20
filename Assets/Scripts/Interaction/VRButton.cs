using UnityEngine;
using UnityEngine.UI;

namespace VisitaVirtual.Interaction
{
    public class VRButton : Interactable
    {
        // Cached References
        private Image buttonImage;

        private void Awake()
        {
            buttonImage = GetComponent<Image>();
        }

        public override void EnableHighlight() => buttonImage.color = Color.cyan;

        public override void DisableHighlight() => buttonImage.color = Color.white;

        public override bool PlayerAtCorrectLocation() => true;
    }
}