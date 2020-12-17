using TMPro;
using UnityEngine;

namespace VisitaVirtual.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI locationText; 
        public void UpdateLocation(string text) => locationText.text = text;
    }
}