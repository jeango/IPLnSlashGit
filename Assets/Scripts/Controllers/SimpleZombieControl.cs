using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombieControl : MonoBehaviour
{
    [SerializeField]
    IPLCharacterController2D controller;

    private void Start()
    {
        controller.HorizontalInput = 1f;
    }
}
