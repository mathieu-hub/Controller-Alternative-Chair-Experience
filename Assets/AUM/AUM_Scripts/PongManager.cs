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

    public GameObject doubleBallBonusPrefab;

    int pongScoreNumber1 = 0;
    int pongScoreNumber2 = 0;

    public bool doubleBonusActive;

    public float minDoubleBallCooldown;
    public float maxDoubleBallCooldown;

    float doubleBallCooldown;
    float doubleBallCooldownTimer;

    [HideInInspector] public List<Animator> bonusPrefabs = new List<Animator>();

    public int levelNumb;

    // Start is called before the first frame update
    void Start()
    {
        pm = this;

        doubleBallCooldownTimer = 0f;

        doubleBallCooldown = Random.Range(minDoubleBallCooldown, maxDoubleBallCooldown);
    }

    private void Update()
    {
        if(doubleBonusActive)
            if (doubleBallCooldownTimer < doubleBallCooldown)
            {
                doubleBallCooldownTimer += Time.deltaTime;
            }
            else
            {
                SpawnDoubleBallBonus();
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

        if(pongScoreNumber1 >= 10) 
        {
            StartCoroutine(ResetScoreAfter(4.5f));

            pongScore1.SetTrigger("LevelUp");
        }
        else
            pongScore1.SetTrigger("Appear");

        if (pongScoreNumber2 >= 10)
        {
            StartCoroutine(ResetScoreAfter(4.5f));

            pongScore2.SetTrigger("LevelUp");
        }
        else
            pongScore2.SetTrigger("Appear");

        SceneManager.LoadScene(0);

    }

    IEnumerator ResetScoreAfter(float time)
    {
        yield return new WaitForSeconds(time);

        levelNumb++;

        pongScoreNumber1 = 0;
        pongScoreNumber2 = 0;
    }
}
