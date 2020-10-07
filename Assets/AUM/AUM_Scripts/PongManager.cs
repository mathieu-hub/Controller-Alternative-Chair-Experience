using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public static PongManager pm;

    public Animator pongScore1;
    public Animator pongScore2;

    int pongScoreNumber1 = 0;
    int pongScoreNumber2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        pm = this;
    }

    public void UpdateScores(int playerWinnerNumber)
    {
        if(playerWinnerNumber == 1)
        {
            pongScoreNumber1 += 1;
        }
        else
        {
            pongScoreNumber2 += 1;
        }

        pongScore1.GetComponent<TextMeshProUGUI>().text = "" + pongScoreNumber1;
        pongScore2.GetComponent<TextMeshProUGUI>().text = "" + pongScoreNumber2;

        pongScore1.SetTrigger("Appear");
        pongScore2.SetTrigger("Appear");
    }
}
