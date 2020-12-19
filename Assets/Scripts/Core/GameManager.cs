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
            // Countdown time until the scenario restarts.
        [SerializeField] private float timeRemaining = 120;
            // ON/OFF switch for the timer in the inspector
        [SerializeField] private bool isTimerRunning = true;
            // Determines the location at which the player starts
        [SerializeField] private Location startingPosition;

        // Cached References
            // Controls information panels at the scene
        [SerializeField] private List<InformationPanel> informationPanels;
            // Controls scene management
        [SerializeField] private SceneLoader sceneLoader;
        
        // Support Variables
            // List of all interactions in the scene
        private List<Interactable> interactions = new List<Interactable>();
            // List of interactions discovered by the player
        private readonly List<Interactable> completedInteractions = new List<Interactable>();
      
        private void Start()
        {
            DisableScreenSleep();
            CacheReferences();
            MovePlayerToStartingPosition();
            UpdateInformationPanels();
        }

        private void Update()
        {
            CountdownTimer();
        }
        
        private void CacheReferences()
        {
            //Find and listen to all interactions available
            interactions = FindObjectsOfType<Interactable>().ToList();
            interactions.ForEach(x => x.onInteraction.AddListener(InteractionExecuted));
        }
        
        private void InteractionExecuted(Interactable interactable)
        {
            CountNewInteraction(interactable);
            UpdateInformationPanels();
        }

        private void CountNewInteraction(Interactable interactable)
        {
            if (completedInteractions.Contains(interactable)) return;
            completedInteractions.Add(interactable);
        }

        private void UpdateInformationPanels()
        {
            var interactionsRemaining = interactions.Count - completedInteractions.Count;
        
            informationPanels.ForEach(x =>
                x.UpdateInteractionsRemainingText(interactionsRemaining));
        }
        
        private void CountdownTimer()
        {
            if (!isTimerRunning) return;

            if (timeRemaining > 0) ContinueCountdown();
            else FinishCountdown();
        }
        
        private void ContinueCountdown()
        {
            timeRemaining -= Time.deltaTime;
            var minutes = Mathf.FloorToInt(timeRemaining / 60);
            var seconds = Mathf.FloorToInt(timeRemaining % 60);
            UpdateTimerPanel(minutes, seconds);
        }

        private void UpdateTimerPanel(int minutes, int seconds)
        {
            var timeLeft = $"{minutes:00}:{seconds:00}";
            informationPanels.ForEach(x => 
                x.UpdateCountdownText(timeLeft));
        }
        
        private void FinishCountdown()
        {
            UpdateTimerPanel(0, 0);
            isTimerRunning = false;
            sceneLoader.LoadStartScene();
        }
        
        private void MovePlayerToStartingPosition()
        {
            startingPosition.onInteraction.Invoke(startingPosition);
        }

        private static void DisableScreenSleep()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}