using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisitaVirtual.Interaction;

namespace VisitaVirtual.Control
{
    public abstract class Selector : MonoBehaviour
    {
        // Config Options
        [SerializeField] private float maxRayDistance = 150;

        // Cached References
        private List<Interactable> interactables;
        
        // Support Fields
        [SerializeField] private GameObject currentTarget;
        [SerializeField] protected Interactable currentInteractable;
     
        private void Start()
        {
            interactables = FindObjectsOfType<Interactable>().ToList();
        }

        private void FixedUpdate()
        {
            SetupInteraction();
        }
        
        private void Update()
        {
            ExecuteInteraction();
        }

        private void SetupInteraction()
        {
            if (RaycastFindsTarget(out var target))
            {
                ManageTarget(target);
            }
            else
            {
                currentTarget = null;
                CancelCurrentInteraction();
            }
        }

        private void ManageTarget(GameObject target)
        {
            if (TargetHasChanged(target)) 
                CancelCurrentInteraction();
            
            if (NewTargetIsInteractable(target, out var targetInteractable))
                PrepareToInteractWithTarget(targetInteractable);
        }

        private void PrepareToInteractWithTarget(Interactable targetInteractable)
        {
            if (currentInteractable == targetInteractable) return;
            currentInteractable = targetInteractable;
            currentInteractable.EnableHighlight();
        }

        protected virtual void CancelCurrentInteraction()
        {
            if (!currentInteractable) return;
            
            currentInteractable.DisableHighlight();
            currentInteractable = null;
        }
        
        protected virtual void ExecuteInteraction()
        {
            
        }

        private bool RaycastFindsTarget(out GameObject target)
        {
            if (RaycastHits(out var hit))
            {
                target = hit.transform.gameObject;
                return true;
            }
            target = null;
            return false;
        }
        
        private bool TargetHasChanged(GameObject target)
        {
            if (target == currentTarget)
            {
                return false;
            }
            currentTarget = target;
            return true;
        }
        
        private bool NewTargetIsInteractable(GameObject target, out Interactable targetInteraction)
        {
            targetInteraction = interactables.FirstOrDefault(interactable =>
                interactable.gameObject == target);
            return targetInteraction && targetInteraction.PlayerAtCorrectLocation();
        }
        
        private bool RaycastHits(out RaycastHit hit)
        {
            return Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance);
        }
    }
}