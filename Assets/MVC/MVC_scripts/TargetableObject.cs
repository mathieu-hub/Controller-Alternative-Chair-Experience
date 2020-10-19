using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{
    //Object
    [Header("Object")]
    public GameObject objectToTarget;
    public GameObject objectTargeted;

    private void Start()
    {
        objectTargeted = null;
    }
    
}

