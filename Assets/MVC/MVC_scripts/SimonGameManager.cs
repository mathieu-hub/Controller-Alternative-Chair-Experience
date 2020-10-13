using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SimonGameManager : MonoBehaviour
{
    public static SimonGameManager sgm;

    [Header("MANCHE COMPOSITOR")]
    public MancheCompositor[] round;

    [Header("ROUND")]
    public int roundIndex;
    public bool roundInProgress = false;
    public int colorIndex;

    [Header("DISPLAY")]
    public int displayIndex;
    public GameObject displayPosition;


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

    void Initialisation()
    {
        displayIndex = 0;
        colorIndex = 0;
        countdown = round[roundIndex].timeToComplete;
        roundInProgress = false;
        round[roundIndex].displayIsPassed = false;
    }

    private void Start()
    {
        sgm = this;

        pointPlayer01 = 0;
        pointPlayer02 = 0;

        roundIndex = 0;

        Initialisation();

        startButton.SetActive(true);
    }

    private void Update()
    {
        if (roundInProgress)
        {
            countdown -= Time.deltaTime;
        }


        //Update de displayPosition
        
        MancheCompositor manche = round[roundIndex];

        displayPosition = manche.displayPositions[displayIndex];

        //Update de objectToTarget

        GetComponent<TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];
    }

    public void StartGame()
    {
        redObject.SetActive(true);
        greenObject.SetActive(true);
        yellowObject.SetActive(true);
        blueObject.SetActive(true);
        StartCoroutine(StartDisplayColor());
    }
    IEnumerator StartDisplayColor()
    {
        MancheCompositor manche = round[roundIndex];

       
        Instantiate(round[roundIndex].colorDisplay[displayIndex], displayPosition.transform.position, displayPosition.transform.rotation);
        yield return new WaitForSeconds(manche.rateDisplay);
        
        
        for (int i = displayIndex; i < manche.maximumIndexDisplay; i++)
        {
            displayIndex++;
            StartCoroutine(StartDisplayColor());
        }

        if(displayIndex == manche.maximumIndexDisplay)
        {
            StartRound();
        }
    }

    void StartRound()
    {
        roundInProgress = true;
        round[roundIndex].displayIsPassed = true;

        EndRound();
    }

    public void ChangeColorSelection()
    {
        colorIndex++;
    }
    void EndRound()
    {
        Debug.Log("roundIsFinish");
        roundIndex++;
        Initialisation();
        StartCoroutine(StartDisplayColor());
    }
}
