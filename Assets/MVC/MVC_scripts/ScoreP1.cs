using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreP1 : MonoBehaviour
{
    Text scorePlayer01;

    // Start is called before the first frame update
    void Start()
    {
        scorePlayer01 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer01.text = SimonGameManager.sgm.pointPlayer01 + "-";
    }
}
