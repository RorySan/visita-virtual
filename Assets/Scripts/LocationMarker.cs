using System;
using UnityEngine;

public class LocationMarker : MonoBehaviour
{
    [SerializeField] private string locationName;
    [SerializeField] private string locationDescription;
   
    public bool HasPlayer { get; set; }
   
    public string GetLocationName()
    {
        return locationName;
    }

    private void OnTriggerEnter(Collider other)
    {
        HasPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        HasPlayer = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
