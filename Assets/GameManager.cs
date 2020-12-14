
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Mover playerMover;
    [SerializeField] private LocationText locationText;
    
    
    private List<PointOfInterest> areas = new List<PointOfInterest>();
    private List<PointOfInterest> visitedAreas = new List<PointOfInterest>();
    
 

    private void Start()
    {
        areas = FindObjectsOfType<PointOfInterest>().ToList();
        areas.ForEach(x => x.onInteraction.AddListener(InteractionDone));
    }


    private void InteractionDone(PointOfInterest point)
    {
        visitedAreas.Add(point);
        if (visitedAreas.Count == areas.Count) Debug.Log("has visitado todo");
        
        Debug.Log("areas totales: " + areas.Count);
        Debug.Log("areas visitadas: " + visitedAreas.Count);

        locationText.UpdateText(point.GetLocationMarker().GetLocationName());
    }
    
}
