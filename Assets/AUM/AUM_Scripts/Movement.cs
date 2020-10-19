using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PScripts pScripts;

    Transform vuforiaPlayerRef;

    public ReadEncoder reRef;

    private void Start()
    {
        vuforiaPlayerRef = GameObject.Find("Player" + pScripts.playerNumber + "Ref").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(vuforiaPlayerRef.position.x, transform.position.y, vuforiaPlayerRef.position.z);

        float rotationValue = (reRef.encoderValue % 80) * (360/80); 

        float zRotation = vuforiaPlayerRef.rotation.eulerAngles.z;

        transform.localRotation = Quaternion.Euler(0f, 0f, rotationValue);
    }
}
