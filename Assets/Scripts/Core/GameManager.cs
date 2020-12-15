using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisitaVirtual.SceneManagement;
using VisitaVirtual.UI;
using VisitaVirtual.Interaction;
using TMPro;

namespace VisitaVirtual.Core
{
    public class GameManager : MonoBehaviour
    {
        // Configuration Options
        [SerializeField] private float timeUntilRestart = 30;
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private bool isTimerRunning = true;
        


        // Cached References
        [SerializeField] private LocationText locationText;
        private SceneLoader sceneLoader;


        private List<PointOfInterest> areas = new List<PointOfInterest>();
        private List<PointOfInterest> visitedAreas = new List<PointOfInterest>();
        
        
        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            
            
            sceneLoader = FindObjectOfType<SceneLoader>();
            areas = FindObjectsOfType<PointOfInterest>().ToList();
            areas.ForEach(x => x.onInteraction.AddListener(InteractionDone));
            //StartCoroutine(RestartAfterTime(timeUntilRestart));
        }

        private void Update()
        {
            if (!isTimerRunning) return;
            
            if (timeUntilRestart > 0)
            {
                timeUntilRestart -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeUntilRestart / 60);  
                float seconds = Mathf.FloorToInt(timeUntilRestart % 60);
                timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                Debug.Log("TAS MUERTO");
                timer.text = string.Format("{0:00}:{1:00}", 0, 0);
                isTimerRunning = false;
            }
        }


        private void InteractionDone(PointOfInterest point)
        {
            visitedAreas.Add(point);
            if (visitedAreas.Count == areas.Count) Debug.Log("has visitado todo");

            Debug.Log("areas totales: " + areas.Count);
            Debug.Log("areas visitadas: " + visitedAreas.Count);

            locationText.UpdateText(point.GetLocationMarker().GetLocationName());
        }


        //private static IEnumerator RestartAfterTime(float time)
        //{
        //    yield return new WaitForSeconds(time);
        //    Debug.Log("VARestart");
            //sceneLoader.LoadStartScene();
       // }
        

    }
}