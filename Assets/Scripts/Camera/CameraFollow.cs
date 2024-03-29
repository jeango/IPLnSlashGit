﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target = null;

    Transform myTransform;

    Vector3 originalOffset;

    private void Start()
    {
        myTransform = transform;
        originalOffset = myTransform.position - target.position;
    }

    private void Update()
    {
        if (target != null)
            myTransform.position = target.position + originalOffset;
    }
}
