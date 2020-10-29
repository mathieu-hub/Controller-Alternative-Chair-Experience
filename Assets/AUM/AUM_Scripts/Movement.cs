using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PScripts pScripts;

    ReadEncoder reRef;

    private void Start()
    {
        reRef = GameObject.Find("Player" + pScripts.playerNumber + "Ref").GetComponent<ReadEncoder>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationValue = (reRef.encoderValue % 90) * (360/90); 

        transform.localRotation = Quaternion.Euler(0f, 0f, rotationValue);
    }
}
