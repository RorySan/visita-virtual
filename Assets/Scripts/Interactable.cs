using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : PointOfInterest
{
    public override void Interact()
    {
        if (!targetPosition.HasPlayer) return;
        Debug.Log("ENCIENDE LA TELE");
    }
}
