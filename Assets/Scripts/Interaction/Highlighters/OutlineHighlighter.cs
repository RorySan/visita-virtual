using UnityEngine;

namespace VisitaVirtual.Interaction
{
    public class OutlineHighlighter : MonoBehaviour, IHighlighter
    {
        [SerializeField] private Outline myOutline;

        public void Highlight()
        {
            if (myOutline.enabled) return;
            Debug.Log("highlight enabled");
            myOutline.enabled = true;
        }

        public void CancelHighlight()
        {
            if (myOutline.enabled == false) return;
            Debug.Log("highlight disabled");
            myOutline.enabled = false;
        }
    }
}
