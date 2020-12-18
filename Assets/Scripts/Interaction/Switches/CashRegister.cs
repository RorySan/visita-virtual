using UnityEngine;

namespace VisitaVirtual.Interaction.Switch
{
    public class CashRegister : OneTimeSwitch
    {
        // Cached References
        private AudioSource audioSource;
        [SerializeField] private Animator animator;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        protected override void Execute()
        {
            audioSource.Play();
            animator.SetTrigger("ServeBeer");
        }
    }
}