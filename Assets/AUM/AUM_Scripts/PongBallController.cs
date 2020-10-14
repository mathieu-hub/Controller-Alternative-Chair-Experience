using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator animator;

    public LineRenderer lr;

    public int playerNumberTarget;

    Transform playerTarget;
    Transform nonPlayerTarget;

    public float speedImpulse;
    [HideInInspector] public float baseSpeedImpulse;

    public float speedAttraction;
    [HideInInspector] public float baseSpeedAttraction;

    public float speedImpulseLimit;
    public float speedAttractionLimit;

    bool stopped;

    public Gradient colorGradient1;
    public Gradient colorGradient2;

    public List<Animator> otherBallsAnimators;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("LancerBall", 3f);

        //rb.AddForce(Vector3.up);

        if(baseSpeedImpulse == 0)
            baseSpeedImpulse = speedImpulse;

        if (baseSpeedAttraction == 0)
            baseSpeedAttraction = speedAttraction;

        playerTarget = GameObject.Find("Player" + playerNumberTarget).transform;

        if(playerNumberTarget == 1)
        {
            nonPlayerTarget = GameObject.Find("Player2").transform;
        }
        else
        {
            nonPlayerTarget = GameObject.Find("Player1").transform;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ShieldPong")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Bump");

            rb.velocity = (((transform.position - playerTarget.position).normalized * 1f) + ((transform.position - collision.transform.position).normalized * 1f)).normalized * speedImpulse;

            nonPlayerTarget = playerTarget;

            if (playerNumberTarget == 1)
            {
                playerNumberTarget = 2;

                gameObject.layer = 10;

            }
            else
            {
                playerNumberTarget = 1;

                gameObject.layer = 9;
            }

            playerTarget = GameObject.Find("Player" + playerNumberTarget).transform;


            if (speedImpulse * 1.5f < speedImpulseLimit * PongManager.pm.levelNumb)
                speedImpulse *= 1.5f;
            else
                speedImpulse = speedImpulseLimit;

            if (speedAttraction * 1.5f < speedAttractionLimit * PongManager.pm.levelNumb)
                speedAttraction *= 1.5f;
            else
                speedAttraction = speedAttractionLimit;

        }
        else if(collision.transform.tag == "Player")
        {
            PongManager.pm.UpdateScores(collision.gameObject.GetComponent<PScripts>().playerNumber);

            GameObject[] bps = GameObject.FindGameObjectsWithTag("BallePong");

            foreach(GameObject bp in bps)
            {
                if(bp.GetComponent<PongBallController>() != this)
                {
                    Destroy(bp);
                }
            }

            rb.velocity = Vector2.zero;

            stopped = true;

            animator.SetTrigger("Reset");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stopped == false)
            rb.AddForce( ( (playerTarget.position - transform.position).normalized  * speedAttraction) * Mathf.Max(1, 1 / (Vector3.Distance(playerTarget.position, transform.position)) / 5f) );

        lr.SetPosition(0, transform.position);

        StartCoroutine(UpdateLineRendererPosition(transform.position));

        if(stopped == false)
            if (playerNumberTarget == 2)
                lr.colorGradient = colorGradient1;
            else
                lr.colorGradient = colorGradient2;
    }

    IEnumerator UpdateLineRendererPosition(Vector2 position)
    {
        yield return new WaitForSeconds(0.1f);

        lr.SetPosition(1, position);
    }

    public void ResetBallStats()
    {
        speedImpulse = baseSpeedImpulse;

        speedAttraction = baseSpeedAttraction;
    }

    public void ResetPosition()
    {
        lr.enabled = false;

        transform.position = Vector2.zero;

        rb.velocity = Vector2.zero;
    }

    public void LaunchBall()
    {
        lr.enabled = true;

        stopped = false;
    }
}
