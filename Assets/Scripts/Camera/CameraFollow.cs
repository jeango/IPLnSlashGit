using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Transform myTransform;

    Vector3 originalOffset;

    private void Start()
    {
        myTransform = transform;
        originalOffset = myTransform.position - target.position;
    }

    private void Update()
    {
        myTransform.position = target.position + originalOffset;
    }
}
