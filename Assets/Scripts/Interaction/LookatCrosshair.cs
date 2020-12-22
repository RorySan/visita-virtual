using UnityEngine;
using UnityEngine.UI;

namespace Interaction
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
            timer = 0;
        }

        public void DeactivateCrosshair()
        {
            crosshairActive = false;
            crosshairImage.fillAmount = 0;
        }
    }
}