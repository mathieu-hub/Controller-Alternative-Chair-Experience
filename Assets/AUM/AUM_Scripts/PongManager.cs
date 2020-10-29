using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongManager : MonoBehaviour
{
    public static PongManager pm;

    public Animator pongScore1;
    public Animator pongScore2;

    int pongScoreNumber1 = 0;
    int pongScoreNumber2 = 0;

    [Header("DoubleBonus")]

    public bool doubleBonusActive;

    public GameObject doubleBallBonusPrefab;

    public float minDoubleBallCooldown;
    public float maxDoubleBallCooldown;

    float doubleBallCooldown;
    float doubleBallCooldownTimer;

    [Header("FullShieldBonus")]
    
    public bool fullShieldBonusActive;
    public int fullShieldNumberPerRound;

    int fullShieldCurrentNumberPerRound;

    public GameObject fullShieldBallBonusPrefab;

    public float minFullShieldBallCooldown;
    public float maxFullShieldBallCooldown;

    float fullShieldBallCooldown;
    float fullShieldBallCooldownTimer;

    [Header("BricksBonus")]

    public bool bricksBonusActive;

    public GameObject bricksBonusPrefab;

    public float minBricksCooldown;
    public float maxBricksCooldown;

    float bricksCooldown;
    float bricksCooldownTimer;

    public int scoreLevelUp;

    [HideInInspector] public List<Animator> bonusPrefabs = new List<Animator>();

    public int levelNumb;

    // Start is called before the first frame update
    void Start()
    {
        pm = this;

        doubleBallCooldownTimer = 0f;

        fullShieldBallCooldownTimer = 0f;

        doubleBallCooldown = Random.Range(minDoubleBallCooldown, maxDoubleBallCooldown);

        fullShieldBallCooldown = Random.Range(minFullShieldBallCooldown, maxFullShieldBallCooldown);
    }

    private void Update()
    {
        if(levelNumb == 1)
        {
            doubleBonusActive = false;
            fullShieldBonusActive = true;
            bricksBonusActive = false;
        }
        else if(levelNumb == 2)
        {
            doubleBonusActive = false;
            fullShieldBonusActive = true;
            bricksBonusActive = true;
        }
        else if(levelNumb == 3)
        {
            doubleBonusActive = true;
            fullShieldBonusActive = true;
            bricksBonusActive = true;
        }

        if(doubleBonusActive)
            if (doubleBallCooldownTimer < doubleBallCooldown)
            {
                doubleBallCooldownTimer += Time.deltaTime;
            }
            else
            {
                SpawnDoubleBallBonus();
            }

        if(fullShieldBonusActive)
            if(fullShieldBallCooldownTimer < fullShieldBallCooldown)
            {
                fullShieldBallCooldownTimer += Time.deltaTime;
            }
            else
            {
                SpawnFullShieldBonus();
            }

        if (bricksBonusActive)
            if (bricksCooldownTimer < bricksCooldown)
            {
                bricksCooldownTimer += Time.deltaTime;
            }
            else
            {
                SpawnBricksBonus();
            }
    }

    void SpawnDoubleBallBonus()
    {
        Animator dbbp = Instantiate(doubleBallBonusPrefab).GetComponent<Animator>();

        dbbp.transform.position = new Vector2(Random.Range(-0.7f, 0.7f), Random.Range(-1.3f, 1.3f));

        bonusPrefabs.Add(dbbp);

        doubleBallCooldownTimer = 0;

        doubleBallCooldown = Random.Range(minDoubleBallCooldown, maxDoubleBallCooldown);
    }

    void SpawnFullShieldBonus()
    {
        Animator sfsb = Instantiate(fullShieldBallBonusPrefab).GetComponent<Animator>();

        sfsb.transform.position = new Vector2(Random.Range(-0.7f, 0.7f), Random.Range(-1.3f, 1.3f));

        bonusPrefabs.Add(sfsb);

        fullShieldBallCooldownTimer = 0;

        fullShieldBallCooldown = Random.Range(fullShieldBallCooldown, fullShieldBallCooldown);
    }

    void SpawnBricksBonus()
    {
        BrickMovement bm = Instantiate(bricksBonusPrefab).GetComponent<BrickMovement>();

        if(Random.Range(0, 2) == 0)
        {
            bm.goUp = false;
            bm.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), 3f);
        }
        else
        {
            bm.goUp = true;
            bm.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), -3f);
        }

        if (Random.Range(0, 2) == 0)
        {
            bm.rotateRight = true;
        }
        else
        {
            bm.rotateRight = false;
        }

        bm.movementSpeed = Random.Range(10f, 50f);
        bm.rotationSpeed = Random.Range(10f, 50f);

        bricksCooldownTimer = 0;

        bricksCooldown = Random.Range(minBricksCooldown, maxBricksCooldown);
    }

    public void UpdateScores(int playerWinnerNumber)
    {
        if(playerWinnerNumber == 1)
        {
            pongScoreNumber2 += 1;
        }
        else
        {
            pongScoreNumber1 += 1;
        }

        for(int i = 0; i < bonusPrefabs.Count; i++)
        {
            bonusPrefabs[i].SetTrigger("Disappear");
        }

        pongScore1.GetComponent<TextMeshProUGUI>().text = "" + pongScoreNumber1;
        pongScore2.GetComponent<TextMeshProUGUI>().text = "" + pongScoreNumber2;

        fullShieldNumberPerRound = 1;

        if(pongScoreNumber1 >= scoreLevelUp) 
        {
            StartCoroutine(ResetScoreAfter(4.5f));

            pongScore1.SetTrigger("LevelUp");
        }
        else
            pongScore1.SetTrigger("Appear");

        if (pongScoreNumber2 >= scoreLevelUp)
        {
            StartCoroutine(ResetScoreAfter(4.5f));

            pongScore2.SetTrigger("LevelUp");
        }
        else
            pongScore2.SetTrigger("Appear");

    }

    IEnumerator ResetScoreAfter(float time)
    {
        yield return new WaitForSeconds(time);

        levelNumb++;

        pongScoreNumber1 = 0;
        pongScoreNumber2 = 0;
    }
}
