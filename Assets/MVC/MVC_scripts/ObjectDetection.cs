using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    public GameObject bar;
    public GameObject validationBar;
    public GameObject refuseBar;
    [SerializeField] private GameObject resultBar;
    [SerializeField] private bool canTarget = true;
    [SerializeField] private bool isStartButton;

    private void Start()
    {
        resultBar = null;
    }

    private void Update()
    {
        if (gameObject.GetComponentInParent<TargetableObject>().objectTargeted == gameObject.GetComponentInParent<TargetableObject>().objectToTarget || isStartButton == true)
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
            if(canTarget == true)
            {
                canTarget = false;
                //Debug.Log("an object is target");
                //Debug.Log("je peux plus target");
                gameObject.GetComponentInParent<TargetableObject>().objectTargeted = gameObject;
                StartCoroutine(LoadBar());
            }            
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Viseur") && !canTarget)
        {
            //Debug.Log("je peux target");
            canTarget = true;
            gameObject.GetComponentInParent<TargetableObject>().objectTargeted = null;
            bar.SetActive(false);
        }
    }

    IEnumerator LoadBar()
    {
        yield return new WaitForSeconds(1f);
        if (gameObject.GetComponentInParent<TargetableObject>().objectTargeted != null && !canTarget) //HERE
        {
            //yield return new WaitForSeconds(1f);
            bar.SetActive(true);
            yield return new WaitForSeconds(2f);
            StartCoroutine(ResultBarDisplay());
        }
        /*else
        {
            yield break;
        }*/
    }

    IEnumerator ResultBarDisplay()
    {
        if (gameObject.GetComponentInParent<TargetableObject>().objectTargeted != null && !canTarget)
        {
            canTarget = true;
            bar.SetActive(false);
            resultBar.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            resultBar.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            resultBar.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            resultBar.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            resultBar.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            resultBar.SetActive(false);

            if (!isStartButton && resultBar == validationBar) 
            {
                SimonGameManager.sgm.ChangeColorSelection();
            }

            if (isStartButton)
            {
                SimonGameManager.sgm.StartGame();
                yield return new WaitForSeconds(0.5f);
                gameObject.SetActive(false);
            }
        }        
    }
}
