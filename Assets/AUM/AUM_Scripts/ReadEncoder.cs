using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using System.Globalization;

public class ReadEncoder : MonoBehaviour
{
    public float encoderValue;
    public string imuReference;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    void DataReceived(string data, UduinoDevice board)
    {
        if (board.name == imuReference)
        {
            encoderValue = float.Parse(data, CultureInfo.InvariantCulture);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
