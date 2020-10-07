using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator animator;

    public int playerNumberTarget;

    Transform playerTarget;
    Transform nonPlayerTarget;

    public float speedImpulse;
    float baseSpeedImpulse;

    public float speedAttraction;
    float baseSpeedAttraction;

    public float speedImpulseLimit;
    public float speedAttractionLimit;

    bool stopped;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("LancerBall", 3f);

        //rb.AddForce(Vector3.up);

        baseSpeedImpulse = speedImpulse;
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
            rb.velocity = (((transform.position - playerTarget.position).normalized * 1f) + ((transform.position - playerTarget.GetChild(0).position).normalized * 1f)).normalized * speedImpulse;

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


            if (speedImpulse * 1.5f < speedImpulseLimit)
                speedImpulse *= 1.5f;
            else
                speedImpulse = speedImpulseLimit;

            if (speedAttraction * 1.5f < speedAttractionLimit)
                speedAttraction *= 1.5f;
            else
                speedAttraction = speedAttractionLimit;

        }
        else if(collision.transform.tag == "Player")
        {
            PongManager.pm.UpdateScores(collision.gameObject.GetComponent<PScripts>().playerNumber);

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
    }

    public void ResetBallStats()
    {
        speedImpulse = baseSpeedImpulse;

        speedAttraction = baseSpeedAttraction;
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;

        rb.velocity = Vector2.zero;
    }

    public void LaunchBall()
    {
        stopped = false;
    }
}
