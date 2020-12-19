using UnityEngine;

namespace VisitaVirtual.Interaction.Switch
{
    public class CashRegister : OneTimeSwitch
    {
        // Cached References
        private AudioSource audioSource;
        [SerializeField] private Animator animator;
        private static readonly int ServeBeer = Animator.StringToHash("ServeBeer");

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        protected override void Execute()
        {
            audioSource.Play();
            animator.SetTrigger(ServeBeer);
        }
    }
}