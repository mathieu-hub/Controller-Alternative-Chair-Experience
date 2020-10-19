using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = SimonGameManager.sgm.pointPlayer01 + " - ";
    }
}
