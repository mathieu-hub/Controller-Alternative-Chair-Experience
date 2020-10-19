using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2TargetableObject : MonoBehaviour
{
    [Header("Object")]
    public GameObject objectToTarget;
    public GameObject objectTargeted;

    private void Start()
    {
        objectTargeted = null;
    }
}
