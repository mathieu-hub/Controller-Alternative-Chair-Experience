using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectDetection : MonoBehaviour
{
    [SerializeField] private GameObject resultBar;
    [SerializeField] private GameObject validationBar;
    [SerializeField] private GameObject refuseBar;

    private void Start()
    {
        resultBar = null;
    }

    private void Update()
    {
        if (gameObject.GetComponentInParent<SimonGameManager>().objectTargeted == gameObject.GetComponentInParent<SimonGameManager>().objectToTarget)
        {
            resultBar = validationBar; 
        }
        else
        {
            resultBar = refuseBar;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Viseur"))
        {
            Debug.Log("an object is target");
            gameObject.GetComponentInParent<SimonGameManager>().objectTargeted = gameObject;
            StartCoroutine(LoadBar());
        }        
    }

    IEnumerator LoadBar()
    {
        yield return new WaitForSeconds(0.5f);
        //Jauge jaune qui augmente
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ResultBarDisplay());
    }

    IEnumerator ResultBarDisplay()
    {
        resultBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        resultBar.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        resultBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        resultBar.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        resultBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        resultBar.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
}
