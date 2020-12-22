using UnityEngine;

namespace VisitaVirtual.Interaction
{
   public class MaterialHighlighter : MonoBehaviour, IHighlighter
   {
      [SerializeField] private Material highlightMaterial;
      [SerializeField] private Material defaultMaterial;

      private Renderer myRenderer;

      private void Awake()
      {
         myRenderer = GetComponent<Renderer>();
      }

      public void Highlight()
      {
         myRenderer.material = highlightMaterial;
      }
      
      public void CancelHighlight()
      {
         myRenderer.material = defaultMaterial;
      }
   }

}