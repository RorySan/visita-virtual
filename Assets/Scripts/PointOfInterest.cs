using UnityEngine;

public class PointOfInterest : MonoBehaviour, IInteractable
{
    // config
    [SerializeField] private Outline targetOutline;
    [SerializeField] private Transform targetPosition;

    // cached items
    private Collider myCollider = null;
    

    private void Start()
    {
        myCollider = GetComponent<Collider>();
        
        targetOutline.enabled = false;
    }

    public void Interact(RaycastSelector instigator)
    {
        instigator.GetComponent<Mover>().MoveToPosition(targetPosition);
    }

    public void Highlight()
    {
        targetOutline.enabled = true;
    }

    public void CancelHighlight()
    {
        targetOutline.enabled = false;
    }
}
