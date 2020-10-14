using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Sound : MonoBehaviour
{
    public AK.Wwise.Event RedColorAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Le son passe");
            RedColorAudio.Post(gameObject);
        }
    }
}
