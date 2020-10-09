﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScaleChanger : MonoBehaviour
{
    public int scaleNumber;

    public float[] scales;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(1f, scales[scaleNumber - 1]);
    }
}