using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBallBonus : MonoBehaviour
{
    public GameObject ballePongPrefab;

    //public Animator animator;

    PongBallController pongBallInCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BallePong")
        {
            pongBallInCollision = collision.gameObject.GetComponent<PongBallController>();
        }
    }
}
