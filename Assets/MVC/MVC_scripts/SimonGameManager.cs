using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGameManager : MonoBehaviour
{
    [Header("MANCHE COMPOSITOR")]
    public MancheCompositor[] round;

    [Header("ROUND")]
    public int roundIndex;
    public bool roundInProgress = false;
    public bool gameIsStarted = false;

    [Header("TIME")]
    [SerializeField] private float countdown;

    [Header("PLAYER 01")]
    public int pointPlayer01;

    [Header("PLAYER 02")]
    public int pointPlayer02;
    

    private void Start()
    {
        pointPlayer01 = 0;
        pointPlayer02 = 0;

        roundIndex = 0;
        countdown = round[roundIndex].timeToComplete;
        
        StartGame();
    }

    private void Update()
    {
        if (roundInProgress)
        {
            countdown -= Time.deltaTime;
        }

        if (!roundInProgress && gameIsStarted)
        {
            roundIndex++;
        }
    }

    void StartGame()
    {

    }
}
