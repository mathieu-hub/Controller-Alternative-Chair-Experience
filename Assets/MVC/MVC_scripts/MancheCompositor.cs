using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MancheCompositor 
{
    [Header("Display")]
    public GameObject[] colorDisplay;
    public GameObject[] displayPositions;
    public GameObject displayPosition;
    public float rateDisplay;
    public bool displayIsPassed = false;

    [Header("Round")]
    public GameObject[] colorSelection;
    public int numberOfColor;
    public float timeToComplete;

}
