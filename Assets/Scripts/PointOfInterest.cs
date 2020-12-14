﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PointOfInterest : MonoBehaviour, IInteractable
{
    // config
    [SerializeField] private float interactionTime = 1.5f;
    [SerializeField] private Outline targetOutline;
    [SerializeField] private LocationMarker locationMarker;
    [SerializeField] private bool playerRequiredAtLocation;
    
    //[SerializeField] public UnityEvent onInteraction;
    public OnInteraction onInteraction;

    [System.Serializable]
    public class OnInteraction : UnityEvent<PointOfInterest>
    {
    }

    private bool isInteracting;
    private Coroutine interactionCoroutine;

    private void Start()
    {
        CancelHighlight();
    }

    public void Interact()
    {
        if (locationMarker.HasPlayer != playerRequiredAtLocation) return;
        interactionCoroutine = StartCoroutine(InitiateInteraction());
    }

    public LocationMarker GetLocationMarker()
    {
        return locationMarker;
    }

    public void CancelInteraction()
    {
        if (!isInteracting) return;
        StopCoroutine(interactionCoroutine);
        CancelHighlight();
        isInteracting = false;
        Debug.Log("Interaction Cancelled");
    }
    protected void Highlight()
    {
        targetOutline.enabled = true;
    }

    private void CancelHighlight()
    {
        targetOutline.enabled = false;
    }

    private IEnumerator InitiateInteraction()
    {
        Highlight();
        isInteracting = true;
        Debug.Log("Waiting for interaction time...");
        yield return new WaitForSeconds(interactionTime);
        onInteraction.Invoke(this);
        Debug.Log("Interaction Executed");
    }
    
    
}