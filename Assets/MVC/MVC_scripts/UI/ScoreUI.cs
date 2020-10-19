using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text scoreUI;

    [SerializeField] private bool player01;
    [SerializeField] private bool player02;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player01)
        {
            scoreUI.text = SimonGameManager.sgm.pointPlayer01 + " - ";
        }

        if (player02)
        {
            scoreUI.text = " - " + SimonGameManager.sgm.pointPlayer01;
        }
    }
}
