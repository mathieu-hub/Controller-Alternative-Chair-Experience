using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform vuforiaPlayerRef;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(vuforiaPlayerRef.position.x, transform.position.y, vuforiaPlayerRef.position.z);

        float zRotation = vuforiaPlayerRef.rotation.eulerAngles.z;

        transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}
