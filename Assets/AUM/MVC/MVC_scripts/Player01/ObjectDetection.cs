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

    //Starting Game
    public bool gameIsStart = false;

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
                
                if(SimonGameManager.sgm.itsNotDisplayPhase == true)
                {
                    StartCoroutine(LoadBar());
                }
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
        if (gameObject.GetComponentInParent<TargetableObject>().objectTargeted != null && !canTarget) 
        {
            //yield return new WaitForSeconds(1f);
            bar.SetActive(true);
            yield return new WaitForSeconds(2f);
            StartCoroutine(ResultBarDisplay());
        }
        
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

            //Passer à la couleur suivante ou Recommencer sa composition
            if (!isStartButton && resultBar == validationBar) 
            {
                SimonGameManager.sgm.ChangeColorSelection();
            }

            if (!isStartButton && resultBar == refuseBar)
            {
                SimonGameManager.sgm.ReinitialiseColorProgression();
            }

            if (isStartButton)
            {
                SimonGameManager.sgm.readyToStart++;
                SimonGameManager.sgm.CheckToStart();
                gameObject.SetActive(false);
            }
        }        
    }
}
