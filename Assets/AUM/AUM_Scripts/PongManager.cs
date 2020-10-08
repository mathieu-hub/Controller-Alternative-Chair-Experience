using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public static PongManager pm;

    public Animator pongScore1;
    public Animator pongScore2;

    public GameObject doubleBallBonusPrefab;

    int pongScoreNumber1 = 0;
    int pongScoreNumber2 = 0;

    public float minDoubleBallCooldown;
    public float maxDoubleBallCooldown;

    float doubleBallCooldown;
    float doubleBallCooldownTimer;

    List<Animator> bonusPrefabs = new List<Animator>();

    // Start is called before the first frame update
    void Start()
    {
        pm = this;

        doubleBallCooldownTimer = 0f;

        doubleBallCooldown = Random.Range(minDoubleBallCooldown, maxDoubleBallCooldown);
    }

    private void Update()
    {
        if(doubleBallCooldownTimer < doubleBallCooldown)
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

        pongScore1.GetComponent<TextMeshProUGUI>().text = "" + pongScoreNumber1;
        pongScore2.GetComponent<TextMeshProUGUI>().text = "" + pongScoreNumber2;

        pongScore1.SetTrigger("Appear");
        pongScore2.SetTrigger("Appear");
    }
}
