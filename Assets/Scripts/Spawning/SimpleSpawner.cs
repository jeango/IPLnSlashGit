using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    }

    public void Spawn()
    {
        Instantiate(prefab, myTransform.position, myTransform.rotation);
    }

}
