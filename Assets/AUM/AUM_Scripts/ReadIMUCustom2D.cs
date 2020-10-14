using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using System.Globalization;

public class ReadIMUCustom2D : MonoBehaviour
{
    Vector3 position;
    Vector3 rotation;
    public Vector3 rotationOffset;
    public float speedFactor = 15.0f;
    //public string imuName = "r"; // You should ignore this if there is one IMU.

    public string imuReference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadIMU(string data, UduinoDevice device)
    {
        //Debug.Log(data);
        if (device.name == imuReference)
        {
            string[] values = data.Split('/');
            if (values.Length == 3) // Rotation of the first one 
            {
                float x = float.Parse(values[0], CultureInfo.InvariantCulture);
                float y = float.Parse(values[1], CultureInfo.InvariantCulture);
                float z = float.Parse(values[2], CultureInfo.InvariantCulture);

                this.transform.localPosition = new Vector3(x, y, z) * 0.01f;
            }
            else if (values.Length != 5)
            {
                Debug.LogWarning(data);
            }
            //this.transform.parent.transform.eulerAngles = rotationOffset;
            //  Log.Debug("The new rotation is : " + transform.Find("IMU_Object").eulerAngles);
        }
    }
}
