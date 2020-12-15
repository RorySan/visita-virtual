﻿using System.Collections.Generic;
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
        [SerializeField] private float timeRemaining = 120;
        [SerializeField] private bool isTimerRunning = true;
        [SerializeField] private Interaction.Interaction startingPosition;

        // Cached References
        [SerializeField] private UserInterface userInterface;
        [SerializeField] private List<InformationPanel> informationPanels;
        private SceneLoader sceneLoader;
        
        // Support Variables
        private List<Interaction.Interaction> interactions = new List<Interaction.Interaction>();
        private List<Interaction.Interaction> completedInteractions = new List<Interaction.Interaction>();
      
        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            sceneLoader = FindObjectOfType<SceneLoader>();
            interactions = FindObjectsOfType<Interaction.Interaction>().ToList();
            interactions.ForEach(x => x.onInteraction.AddListener(InteractionDone));
            startingPosition.onInteraction.Invoke(startingPosition);
            UpdateInteractionsPanel();
        }

        private void Update()
        {
            CountdownTimer();
        }
        
        private void InteractionDone(Interaction.Interaction interaction)
        {
            var location = interaction.GetLocationMarker().GetLocationName();
            userInterface.UpdateLocation(location);
            
            if (completedInteractions.Contains(interaction)) return;
            completedInteractions.Add(interaction);
            UpdateInteractionsPanel();
        }
        
        private void UpdateInteractionsPanel()
        {
            var remaining = interactions.Count - completedInteractions.Count;
            informationPanels.ForEach(x =>
                x.UpdateInteractionsRemainingPanel(remaining.ToString()));
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
        
        private void FinishCountdown()
        {
            UpdateTimerPanel(0, 0);
            isTimerRunning = false;
            //sceneLoader.LoadStartScene();
        }

        private void UpdateTimerPanel(int minutes, int seconds)
        {
            var timeLeft = $"{minutes:00}:{seconds:00}";
            informationPanels.ForEach(x => x.UpdateCountdownText(timeLeft));
        }
    }
}