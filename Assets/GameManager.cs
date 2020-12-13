using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Mover playerMover;
    private List<PointOfInterest> areas = new List<PointOfInterest>();

    private void Start()
    {
        areas = FindObjectsOfType<PointOfInterest>().ToList();
        
        
    }
}
