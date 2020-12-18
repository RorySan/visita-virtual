using UnityEngine;
using VisitaVirtual.UI;

namespace VisitaVirtual.Interaction.Switch
{
    public abstract class OneTimeSwitch : MonoBehaviour
    {
        // Cached References
        [SerializeField] private UserInterface userInterface;

        // Support Variables
        private bool alreadyExecuted;

        public void InteractOneTime(string alreadyExecutedMessage)
        {
            if (alreadyExecuted)
            {
                userInterface.PrintMessage(alreadyExecutedMessage);
            }
            else
            {
                alreadyExecuted = true;
                Execute();
            }
        }

        protected virtual void Execute()
        {
        }
    }
}