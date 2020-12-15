
using UnityEngine;
using TMPro;

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

        public void UpdateInteractionsRemainingPanel(string text)
        {
            interactionsRemainingText.text = text;
        }
    }
}