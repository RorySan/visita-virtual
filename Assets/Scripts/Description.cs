using UnityEngine;

public class Description : MonoBehaviour, IInteractable
{

    [SerializeField] private string itemName;
    [SerializeField] private string text;

    public string ItemName
    {
        get;
    }

    public string Text
    {
        get;
    }

    public void CancelHighlight()
    {

    }

    public void Highlight()
    {

    }

    public void Interact(RaycastSelector instigator)
    {

    }
}
