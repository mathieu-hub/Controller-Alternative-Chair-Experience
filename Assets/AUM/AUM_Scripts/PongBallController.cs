using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallController : MonoBehaviour
{
    public Rigidbody rb;

    public int playerNumberTarget;

    Transform playerTarget;
    Transform nonPlayerTarget;

    public float speedImpulse;

    public float speedImpulseMultiplier;

    public float speedAttraction;

    public float speedImpulseLimit;
    public float speedAttractionLimit;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("LancerBall", 3f);

        //rb.AddForce(Vector3.up);

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "ShieldPong")
        {
            rb.velocity = (  ( (transform.position - playerTarget.position).normalized * 1f ) + ( (transform.position - playerTarget.GetChild(0).position).normalized * 1f )  ).normalized * speedImpulse;

            nonPlayerTarget = playerTarget;

            if(playerNumberTarget == 1)
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

            
            if (speedImpulse < speedImpulseLimit)
                speedImpulse += 1f;

            if (speedAttraction < speedAttractionLimit)
                speedAttraction += 1f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce( ( (playerTarget.position - transform.position).normalized  * speedAttraction) * Mathf.Max(1, 1 / (Vector3.Distance(playerTarget.position, transform.position)) / 5f) );
    }

    void LancerBall()
    {

    }
}
