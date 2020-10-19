using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBallBonus : MonoBehaviour
{
    public Animator animator;

    PongBallController pongBallInCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BallePong")
        {
            pongBallInCollision = collision.gameObject.GetComponent<PongBallController>();

            pongBallInCollision.rb.velocity = Vector2.zero;

            pongBallInCollision.nonPlayerTarget.shieldPongBonusAnimator.SetTrigger("Appear");

            animator.SetTrigger("Disappear");
        }
    }

    void DestroyTheObject()
    {
        PongManager.pm.bonusPrefabs.Remove(animator);

        Destroy(gameObject);
    }
}
