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
        [SerializeField] private float gameTimeRemaining = 120;
        [SerializeField] private bool isGameTimerRunning = true;
        [SerializeField] private Location playerStartingPosition;
        // List of interactions not to be tracked
        [SerializeField] private List<Interactable> interactablesIgnored = new List<Interactable>();
        
        // Support Fields
            // List of all interactions in the scene
        private List<Interactable> interactablesAvailable = new List<Interactable>();
            // List of interactions discovered by the player
        private readonly List<Interactable> interactablesUsed = new List<Interactable>();
            
        // Cached References
        [SerializeField] private List<InformationPanel> informationPanels;
        [SerializeField] private SceneLoader sceneLoader;
      
        private void Start()
        {
            DisableDeviceScreenSleep();
            ListenToInteractables();
            MovePlayerToStartingPosition();
        }

        private void Update()
        {
            CountdownGameTimer();
        }
        
        private void ListenToInteractables()
        {
            interactablesAvailable = FindObjectsOfType<Interactable>()
                .Except(interactablesIgnored).ToList();
            interactablesAvailable.ForEach(interactable =>
                interactable.onInteraction.AddListener(InteractionExecuted));
        }
        
        private void InteractionExecuted(Interactable interactable)
        {
            CountNewInteraction(interactable);
            UpdateInformationPanels();
        }

        private void CountNewInteraction(Interactable interactable)
        {
            if (interactablesUsed.Contains(interactable)) return;
            interactablesUsed.Add(interactable);
        }

        private void UpdateInformationPanels()
        {
            int interactionsRemaining = interactablesAvailable.Count - interactablesUsed.Count;
        
            informationPanels.ForEach(informationPanel =>
                informationPanel.UpdateInteractionsRemainingText(interactionsRemaining));
        }
        
        private void CountdownGameTimer()
        {
            if (!isGameTimerRunning) return;

            if (gameTimeRemaining > 0) ContinueCountdown();
            else FinishCountdown();
        }
        
        private void ContinueCountdown()
        {
            gameTimeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(gameTimeRemaining / 60);
            int seconds = Mathf.FloorToInt(gameTimeRemaining % 60);
            UpdateTimerPanel(minutes, seconds);
        }

        private void UpdateTimerPanel(int minutes, int seconds)
        {
            var timeLeft = $"{minutes:00}:{seconds:00}";
            informationPanels.ForEach(informationPanel => 
                informationPanel.UpdateCountdownText(timeLeft));
        }
        
        private void FinishCountdown()
        {
            UpdateTimerPanel(0, 0);
            isGameTimerRunning = false;
            sceneLoader.LoadStartScene();
        }
        
        private void MovePlayerToStartingPosition()
        {
            playerStartingPosition.Interact();
        }

        private static void DisableDeviceScreenSleep()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}