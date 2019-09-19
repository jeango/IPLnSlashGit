using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IPLCharacterController2D: MonoBehaviour
{

    // add speed control
    [SerializeField]
    int speed;

    float horizontalSpeed;

    Transform myTransform;
    Rigidbody2D myRigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ReadInput()
    {
        horizontalSpeed = Input.GetAxis("Horizontal") * speed;
    }

    private void Move()
    {
        //        transform.Translate(new Vector2(horizontalSpeed, 0f));
        myRigidbody.velocity = new Vector2(horizontalSpeed, myRigidbody.velocity.y);
    }
}
