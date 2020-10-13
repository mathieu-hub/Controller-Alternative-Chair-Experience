using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{
    //Object
    [Header("Object")]
    public GameObject objectToTarget;
    public GameObject objectTargeted;

    [Header("Color Validation")]
    public bool colorisValid = false;

    private void Start()
    {
        objectTargeted = null;
    }

    private void Update()
    {
        print(objectTargeted);
    }
}

