using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float movementSpeed;
    public float rotationSpeed;

    public bool goUp;

    public bool rotateRight;

    public float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goUp == true)
        {
            rb.velocity = Vector2.up * movementSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.down * movementSpeed * Time.deltaTime;
        }

        if(rotateRight == true)
        {
            transform.Rotate(new Vector3(0, 0, 1 * Time.deltaTime * rotationSpeed));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -1 * Time.deltaTime * rotationSpeed));
        }

        lifeTimer -= Time.deltaTime;

        if(lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
