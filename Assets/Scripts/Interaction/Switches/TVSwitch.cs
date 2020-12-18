using System.Collections.Generic;
using UnityEngine;

namespace VisitaVirtual.Interaction.Switch
{
    public class TVSwitch : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> tvSprites = new List<SpriteRenderer>();

        private bool isOn;

        private void Start()
        {
            tvSprites.ForEach(x => x.enabled = false);
        }

        public void Switch()
        {
            tvSprites.ForEach(x => x.enabled = !isOn);
            isOn = !isOn;
        }
    }
}