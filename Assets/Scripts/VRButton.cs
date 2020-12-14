using UnityEngine;
using UnityEngine.UI;

public class VRButton : PointOfInterest
{
    private Image buttonImage;
    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }
    protected override void Highlight()
    {
        buttonImage.color = Color.green;
    }
    public override void Interact()
    {
        interactionCoroutine = StartCoroutine(InitiateInteraction());
    }
    protected override void CancelHighlight()
    {
        buttonImage.color = Color.cyan;
    }
}
