using UnityEngine;
using UnityEngine.UI;

namespace VisitaVirtual.Control
{
    public class LookatCrosshair : MonoBehaviour
    {
        
        // Cached References
        [SerializeField] private Image crosshairImage;
        
        // Support Properties
        public float InteractionTime { get; set; }
        private float timer;
        private bool crosshairActive;

        private void Update()
        {
            if (!crosshairActive) return;
            
            timer += Time.deltaTime;
            crosshairImage.fillAmount = timer / InteractionTime;
        }

        public void ActivateCrosshair()
        {
            crosshairActive = true;
            
        }

        public void DeactivateCrosshair()
        {
            crosshairActive = false;
            crosshairImage.fillAmount = 0;
            timer = 0;
        }
    }
}