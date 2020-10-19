using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoundUI : MonoBehaviour
{
    Text roundUI;

    // Start is called before the first frame update
    void Start()
    {
        roundUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        roundUI.text = "Round " + SimonGameManager.sgm.roundUI;
    }
}
