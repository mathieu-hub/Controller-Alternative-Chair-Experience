using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGameManager : MonoBehaviour
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
}
