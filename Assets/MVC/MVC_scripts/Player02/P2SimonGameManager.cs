using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2SimonGameManager : MonoBehaviour
{
    public static P2SimonGameManager p2sgm;

    [Header("MANCHE COMPOSITOR")]
    public P2MancheCompositor[] round;

    [Header("ROUND")]
    public int roundIndex;
    public int roundNumber;
    public bool roundInProgress = false;
    public int colorIndex;

    [Header("DISPLAY")]
    public int displayIndex;
    public GameObject displayPosition;
    public bool itsNotDisplayPhase = true;
    [SerializeField] private List<GameObject> spawnedColor;

    [Header("TIME")]
    public float countdown;
    public float timeBreak = 2;
    public bool timeBreaking = false;

    [Header("PLAYER 01")]
    public GameObject player02;
    public int pointPlayer02;
    public bool player02Win = false;


    [Header("OBJECT TRIGGER")]
    public GameObject redObject;
    public GameObject greenObject;
    public GameObject yellowObject;
    public GameObject blueObject;
    public GameObject startButton;

    [Header("UI")]
    public GameObject scoreUI;
    public GameObject roundUI;



    private P2MancheCompositor manche;
    void Initialisation()
    {
        displayIndex = 0;
        colorIndex = 0;
        countdown = round[roundIndex].timeToComplete;
        roundInProgress = false;
        round[roundIndex].displayIsPassed = false;

        DisplayUI();
    }

    private void Start()
    {
        p2sgm = this;

        P2MancheCompositor manche = round[roundIndex];

        spawnedColor = new List<GameObject>();

        pointPlayer02 = 0;

        roundIndex = 0;

        roundNumber = roundIndex += 1;

        Initialisation();

        startButton.SetActive(true);

        gameObject.GetComponentInChildren<P2TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];

    }

    private void Update()
    {
        //COUNTDOWN
        if (roundInProgress)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            EndRound();
        }

        //TIMEBREAK
        if (timeBreaking)
        {
            timeBreak -= Time.deltaTime;
        }

        if (timeBreak <= 0)
        {
            timeBreak = 2;
            timeBreaking = false;
            scoreUI.SetActive(false);
            roundUI.SetActive(false);
            StartCoroutine(StartDisplayColor());
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
        itsNotDisplayPhase = false;

        P2MancheCompositor manche = round[roundIndex];

        gameObject.GetComponentInChildren<P2TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];
        yield return new WaitForSeconds(manche.rateDisplay);
        Debug.Log("instanciation couleur");
        var _colorDisplay = Instantiate(round[roundIndex].colorDisplay[displayIndex], displayPosition.transform.position, displayPosition.transform.rotation, player02.transform);
        spawnedColor.Add(_colorDisplay);
        yield return new WaitForSeconds(0.8f);
        displayIndex++;

        if (displayIndex < manche.maximumIndexDisplay)
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
        itsNotDisplayPhase = true;
        roundInProgress = true;
        round[roundIndex].displayIsPassed = true;
    }

    public void ChangeColorSelection()
    {
        P2MancheCompositor manche = round[roundIndex];

        Debug.Log("CHANGEMENT DE COULEUR");
        colorIndex++;
        gameObject.GetComponentInChildren<P2TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];

        if (colorIndex == manche.maximumIndexColor)
        {
            player02Win = true;
            pointPlayer02++;

            if (player02Win && SimonGameManager.sgm.player01Win == true)
            {
                EndRound();
            }
        }
    }

    public void ReinitialiseColorProgression()
    {
        Debug.Log("RETRY COLOR PROGRESSION");
        colorIndex = 0;
        gameObject.GetComponentInChildren<P2TargetableObject>().objectToTarget = manche.colorSelection[colorIndex];
    }

    void DisplayUI()
    {
        timeBreaking = true;
        scoreUI.SetActive(true);
        roundUI.SetActive(true);
    }

    void EndRound()
    {
        Debug.Log("roundIsFinish");
        roundIndex++;
        roundNumber++;
        Initialisation();
        //StartCoroutine(StartDisplayColor());
    }
}
