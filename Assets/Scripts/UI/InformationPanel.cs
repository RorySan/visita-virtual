
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace VisitaVirtual.UI
{
    public class InformationPanel : MonoBehaviour
    {
        // Configuration Options
        [SerializeField] private string doneText = "Done";
        
        // Cached References
        [SerializeField] private TextMeshProUGUI countdownText;
        [SerializeField] private TextMeshProUGUI interactionsRemainingText;

        public void UpdateCountdownText(string text)
        {
            countdownText.text = text;
        }

        public void UpdateInteractionsRemainingText(int interactionsRemaining)
        {
            var text = interactionsRemaining == 0 ? doneText : interactionsRemaining.ToString();
            interactionsRemainingText.text = text;
        }
    }
}