using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisitaVirtual.SceneManagement;
using VisitaVirtual.UI;
using VisitaVirtual.Interaction;


namespace VisitaVirtual.Core
{
    public class GameManager : MonoBehaviour
    {
        // Configuration Options
        [SerializeField] private float timeUntilRestart = 30;
        [SerializeField] private bool isTimerRunning = true;

        // Cached References
        //[SerializeField] private List<TextMeshProUGUI> timerTexts;
        [SerializeField] private List<InformationPanel> informationPanels;
        [SerializeField] private UserInterface userInterface;
        private SceneLoader sceneLoader;

        private List<PointOfInterest> areas = new List<PointOfInterest>();
        private List<PointOfInterest> visitedAreas = new List<PointOfInterest>();
        private int interactionsRemaining;
        
        
        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            sceneLoader = FindObjectOfType<SceneLoader>();
            areas = FindObjectsOfType<PointOfInterest>().ToList();
            areas.ForEach(x => x.onInteraction.AddListener(InteractionDone));
            interactionsRemaining = areas.Count;
            UpdateInteractionsPanel();
        }

        private void UpdateInteractionsPanel()
        {
            var text = interactionsRemaining.ToString();
            informationPanels.ForEach(x =>
                x.UpdateInteractionsRemainingText(text));
        }

        private void Update()
        {
            RunTimer();
        }

        private void RunTimer()
        {
            if (!isTimerRunning) return;

            if (timeUntilRestart > 0)
            {
                timeUntilRestart -= Time.deltaTime;
                var minutes = Mathf.FloorToInt(timeUntilRestart / 60);
                var seconds = Mathf.FloorToInt(timeUntilRestart % 60);
                informationPanels.ForEach(x =>
                    x.UpdateCountdownText($"{minutes:00}:{seconds:00}"));
            }
            else
            {
                //sceneLoader.LoadStartScene();
                informationPanels.ForEach(x =>
                    x.UpdateCountdownText($"{0:00}:{0:00}"));
                isTimerRunning = false;
            }
        }

        private void InteractionDone(PointOfInterest point)
        {
            userInterface.UpdateLocation(point.GetLocationMarker().GetLocationName());
            
            if (visitedAreas.Contains(point)) return;
            visitedAreas.Add(point);
            interactionsRemaining -= 1;
            var text = interactionsRemaining.ToString();
            UpdateInteractionsPanel();
            
        }
    }
}