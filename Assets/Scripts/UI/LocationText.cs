using TMPro;
using UnityEngine;

namespace VisitaVirtual.UI
{
    public class LocationText : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateText(string location)
        {
            text.text = location;
        }
    }
}