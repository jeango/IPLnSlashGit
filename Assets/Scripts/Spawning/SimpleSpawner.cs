﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    public Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    public void Spawn()
    {
        //        var obj = Instantiate(prefab, myTransform.position, myTransform.rotation);
        var obj = Pooling.Acquire(prefab);
        obj.transform.position = myTransform.position;
        obj.transform.rotation = myTransform.rotation;
        obj.layer = gameObject.layer;
        foreach (Transform item in obj.transform)
        {
            item.gameObject.layer = gameObject.layer;
        }
    }

}
