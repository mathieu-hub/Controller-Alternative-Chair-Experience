using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    Text countdownUI;

    // Start is called before the first frame update
    void Start()
    {
        countdownUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownUI.text = SimonGameManager.sgm.countdown + "";
    }
}
