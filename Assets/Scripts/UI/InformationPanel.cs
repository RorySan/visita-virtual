
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace VisitaVirtual.UI
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdownText;
        [SerializeField] private TextMeshProUGUI interactionsRemainingText;

        public void UpdateCountdownText(string text)
        {
            countdownText.text = text;
        }

        public void UpdateInteractionsRemainingText(int interactionsRemaining)
        {
            string text;
            if (interactionsRemaining == 0) text = "Done";
            else text = interactionsRemaining.ToString();
            
            interactionsRemainingText.text = text;
        }
    }
}