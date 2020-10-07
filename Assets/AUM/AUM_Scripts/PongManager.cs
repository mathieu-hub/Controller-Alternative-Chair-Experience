using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public static PongManager pm;

    public Animator pongScore1;
    public Animator pongScore2;

    // Start is called before the first frame update
    void Start()
    {
        pm = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScores(int playerNumber)
    {
        if(playerNumber == 1)
        {
            pongScore1.GetComponent<TextMeshProUGUI>().text += 1;
        }
        else
        {
            pongScore2.GetComponent<TextMeshProUGUI>().text += 1;
        }

        pongScore1.SetTrigger("Appear");
        pongScore2.SetTrigger("Appear");
    }
}
