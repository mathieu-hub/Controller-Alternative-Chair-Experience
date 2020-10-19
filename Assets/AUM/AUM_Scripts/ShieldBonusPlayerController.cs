using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonusPlayerController : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BallePong")
        {            
            animator.SetTrigger("Disappear");
        }
    }

}
