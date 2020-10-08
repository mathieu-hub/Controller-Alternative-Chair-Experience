using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBallBonus : MonoBehaviour
{
    public GameObject ballePongPrefab;

    public Animator animator;

    PongBallController pongBallInCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BallePong")
        {
            pongBallInCollision = collision.gameObject.GetComponent<PongBallController>();

            PongBallController pbc = Instantiate(ballePongPrefab).GetComponent<PongBallController>();

            pongBallInCollision.rb.velocity = Vector2.zero;

            pbc.transform.position = transform.position;

            pbc.speedImpulse = pongBallInCollision.speedImpulse;
            pbc.speedAttraction = pongBallInCollision.speedAttraction;

            pbc.baseSpeedImpulse = pongBallInCollision.baseSpeedImpulse;
            pbc.baseSpeedAttraction = pongBallInCollision.baseSpeedAttraction;

            pbc.lr.SetPosition(1, pbc.transform.position);

            if (pongBallInCollision.playerNumberTarget == 1)
            {
                pbc.playerNumberTarget = 2;

                pbc.gameObject.layer = 10;
            }
            else
            {
                pbc.playerNumberTarget = 1;

                pbc.gameObject.layer = 9;
            }

            animator.SetTrigger("Disappear");
        }
    }

    void DestroyTheObject()
    {
        Destroy(gameObject);
    }
}
