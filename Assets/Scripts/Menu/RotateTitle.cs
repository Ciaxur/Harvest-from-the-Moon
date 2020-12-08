﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTitle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(0, 0, Time.deltaTime * -30.0f));
    }
}
