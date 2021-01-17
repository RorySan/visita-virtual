using System.Collections;
using TMPro;
using UnityEngine;

namespace VisitaVirtual.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI locationText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private float messageDisplayTime = 2f;

        private Coroutine messageCoroutine;
        
        public void UpdateLocation(string text) => locationText.text = text;

        public void PrintMessage(string text) => 
            messageCoroutine = StartCoroutine(DisplayMessageForSeconds(text));

        private IEnumerator DisplayMessageForSeconds(string message)
        {
            ResetMessageDisplay();
            messageText.text = message;
            yield return new WaitForSeconds(messageDisplayTime);
            messageText.text = "";
        }

        private void ResetMessageDisplay()
        {
            if (messageCoroutine != null) StopCoroutine(messageCoroutine);
        }
    }
}