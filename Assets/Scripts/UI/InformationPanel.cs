using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI interactionsRemainingText;

    public void UpdateCountdownText(string text)
    {
        countdownText.text = text;
    }

    public void UpdateInteractionsRemainingText(string text)
    {
        interactionsRemainingText.text = text;
    }
}
