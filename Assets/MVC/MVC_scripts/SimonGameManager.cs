using System;
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
    [SerializeField] private List<GameObject> spawnedColor;

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

    private MancheCompositor manche;
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

        MancheCompositor manche = round[roundIndex];

        spawnedColor = new List<GameObject>();

        pointPlayer01 = 0;
        pointPlayer02 = 0;

        roundIndex = 0;

        Initialisation();

        startButton.SetActive(true);

        gameObject.GetComponentInChildren<TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];

    }

    private void Update()
    {
        if (roundInProgress)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            EndRound();
        }

        //Update de displayPosition

        manche = round[roundIndex];

        displayPosition = manche.displayPositions[displayIndex];
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

        yield return new WaitForSeconds(manche.rateDisplay);
        Debug.Log("instanciation couleur");
        var _colorDisplay = Instantiate(round[roundIndex].colorDisplay[displayIndex], displayPosition.transform.position, displayPosition.transform.rotation);
        spawnedColor.Add(_colorDisplay);
        yield return new WaitForSeconds(0.8f);
        displayIndex++;

        if(displayIndex < manche.maximumIndexDisplay)
        {
            displayPosition = manche.displayPositions[displayIndex];
            StartCoroutine(StartDisplayColor());
        }


        if (displayIndex == manche.maximumIndexDisplay)
        {
            yield return new WaitForSeconds(manche.rateDisplay);

            foreach (GameObject color in spawnedColor)
            {
                Destroy(color);
            }
            
            StartRound();
        }
    }

    void StartRound()
    {
        MancheCompositor manche = round[roundIndex];

        roundInProgress = true;
        round[roundIndex].displayIsPassed = true;

        if (colorIndex == manche.maximumIndexColor)
        {
            EndRound();
        }
    }

    public void ChangeColorSelection()
    {
        MancheCompositor manche = round[roundIndex];

        Debug.Log("CHANGEMENT DE COULEUR");
        colorIndex++;
        gameObject.GetComponentInChildren<TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];
    }
    void EndRound()
    {
        Debug.Log("roundIsFinish");
        roundIndex++;
        Initialisation();
        StartCoroutine(StartDisplayColor());
    }
}
