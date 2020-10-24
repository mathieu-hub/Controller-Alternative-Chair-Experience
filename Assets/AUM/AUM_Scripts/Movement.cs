using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PScripts pScripts;

    public ReadEncoder reRef;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(vuforiaPlayerRef.position.x, transform.position.y, vuforiaPlayerRef.position.z);

        float rotationValue = (reRef.encoderValue % 80) * (360/80); 

        transform.localRotation = Quaternion.Euler(0f, 0f, rotationValue);
    }
}
