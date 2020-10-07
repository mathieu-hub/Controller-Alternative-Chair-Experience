using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBallBonus : MonoBehaviour
{
    public GameObject ballePongPrefab;

    PongBallController pongBallInCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BallePong")
        {
            pongBallInCollision = collision.gameObject.GetComponent<PongBallController>();

            PongBallController pbc = Instantiate(ballePongPrefab).GetComponent<PongBallController>();

            pbc.transform.position = Vector2.zero;

            pbc.speedImpulse = pongBallInCollision.speedImpulse;
            pbc.speedAttraction = pongBallInCollision.speedAttraction;

            if (pongBallInCollision.playerNumberTarget == 1)
                pbc.playerNumberTarget = 2;
            else
                pbc.playerNumberTarget = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
