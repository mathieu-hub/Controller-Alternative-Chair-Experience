using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGameManager : MonoBehaviour
{
    public static SimonGameManager sgm;

    [Header("MANCHE COMPOSITOR")]
    public MancheCompositor[] round;

    [Header("ROUND")]
    public int roundIndex;
    public bool roundInProgress = false;

    [Header("DISPLAY")]
    public int displayIndex;

    [Header("TIME")]
    public float countdown;

    [Header("PLAYER 01")]
    public int pointPlayer01;

    [Header("PLAYER 02")]
    public int pointPlayer02;

    [Header("OBJECT TRIGGER")]
    public GameObject redObject;
    public GameObject greenObject;
    public GameObject yellowObject;
    public GameObject blueObject;
    public GameObject startButton;



    private void Start()
    {
        sgm = this;

        pointPlayer01 = 0;
        pointPlayer02 = 0;

        roundIndex = 0;
        countdown = round[roundIndex].timeToComplete;

        startButton.SetActive(true);
    }

    private void Update()
    {
        if (roundInProgress)
        {
            countdown -= Time.deltaTime;
        }

        if (!roundInProgress && round[roundIndex].displayIsPassed == true)
        {
            Debug.Log("roundIsFinish");
            roundIndex++;
            countdown = round[roundIndex].timeToComplete;
        }
    }

    public void StartGame()
    {

        StartDisplayColor();
    }
    void StartDisplayColor()
    {
        StartRound();
    }

    void StartRound()
    {

    }
}
