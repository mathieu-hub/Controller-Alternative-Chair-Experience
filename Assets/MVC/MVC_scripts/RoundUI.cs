using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoundUI : MonoBehaviour
{
    Text roundText;

    // Start is called before the first frame update
    void Start()
    {
        roundText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = "Round " + SimonGameManager.sgm.roundNumber;
    }
}
