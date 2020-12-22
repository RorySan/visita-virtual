using UnityEngine;
using UnityEngine.UI;

namespace VisitaVirtual.Interaction
{
    public class ColorHighlighter : MonoBehaviour, IHighlighter
    {
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color highlightColor;
        private bool isHighlighted;

        private Image myImage;
        
        private void Awake()
        {
            myImage = GetComponent<Image>();
        }

        public void Highlight()
        {
            if (isHighlighted) return;
            myImage.color = highlightColor;
            isHighlighted = true;
        }

        public void CancelHighlight()
        {
            if (!isHighlighted) return;
            myImage.color = defaultColor;
            isHighlighted = false;
        }
    }
}