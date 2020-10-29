using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScaleChanger : MonoBehaviour
{
    public float[] scales;

    float initialYScale;

    private void Start()
    {
        initialYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(transform.localScale.x, scales[PongManager.pm.levelNumb - 1] * initialYScale);
    }
}
