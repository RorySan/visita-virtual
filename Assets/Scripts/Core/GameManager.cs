
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisitaVirtual.SceneManagement;
using VisitaVirtual.Movement;
using VisitaVirtual.UI;
using VisitaVirtual.Interaction;

namespace VisitaVirtual.Core
{
    public class GameManager : MonoBehaviour
    {
        // Configuration Options
        [SerializeField] private float timeUntilRestart = 10;


        // Cached References
        [SerializeField] private Mover playerMover;
        [SerializeField] private LocationText locationText;
        private SceneLoader sceneLoader;


        private List<PointOfInterest> areas = new List<PointOfInterest>();
        private List<PointOfInterest> visitedAreas = new List<PointOfInterest>();

        private void Start()
        {
            sceneLoader = FindObjectOfType<SceneLoader>();
            areas = FindObjectsOfType<PointOfInterest>().ToList();
            areas.ForEach(x => x.onInteraction.AddListener(InteractionDone));
            StartCoroutine(RestartAfterTime(timeUntilRestart));
        }

        private void InteractionDone(PointOfInterest point)
        {
            visitedAreas.Add(point);
            if (visitedAreas.Count == areas.Count) Debug.Log("has visitado todo");

            Debug.Log("areas totales: " + areas.Count);
            Debug.Log("areas visitadas: " + visitedAreas.Count);

            locationText.UpdateText(point.GetLocationMarker().GetLocationName());
        }

        private static IEnumerator RestartAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("VARestart");
            //sceneLoader.LoadStartScene();
        }

    }
}