using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{
    //Object
    [Header("Object")]
    public GameObject objectToTarget;
    public GameObject objectTargeted;

    //Bar selected
    [Header("Bar Selected")]
    public GameObject barSelected;
    public GameObject valBarSelected;
    public GameObject refBarSelected;

    //Bar Reference
    [Header("BAR REFERENCES")]
    [Header("Bar")]
    [SerializeField] private GameObject bar01;
    [SerializeField] private GameObject bar02;
    [SerializeField] private GameObject bar03;
    [SerializeField] private GameObject bar04;
    [Header("Validation Bar")]
    [SerializeField] private GameObject valBar01;
    [SerializeField] private GameObject valBar02;
    [SerializeField] private GameObject valBar03;
    [SerializeField] private GameObject valBar04;
    [Header("Refuse Bar")]
    [SerializeField] private GameObject refBar01;
    [SerializeField] private GameObject refBar02;
    [SerializeField] private GameObject refBar03;
    [SerializeField] private GameObject refBar04;

    void Update()
    {
        if (barSelected == bar01)
        {
            valBarSelected = valBar01;
            refBarSelected = refBar01;
        }
        else if(barSelected == bar02)
        {
            valBarSelected = valBar02;
            refBarSelected = refBar02;
        }
        else if (barSelected == bar03)
        {
            valBarSelected = valBar03;
            refBarSelected = refBar03;
        }
        else if (barSelected == bar04)
        {
            valBarSelected = valBar04;
            refBarSelected = refBar04;
        }
    }
}

