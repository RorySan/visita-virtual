using System;
using UnityEngine;

public class GizmoSphere : MonoBehaviour
{
    [SerializeField] private string locationName;
    [SerializeField] private string locationDescription;
    [SerializeField] private PointOfInterest pointOfInterest;
    
    public string GetLocationName()
    {
        return locationName;
    }

    private void OnTriggerEnter(Collider other)
    {
        pointOfInterest.HasPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pointOfInterest.HasPlayer = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
