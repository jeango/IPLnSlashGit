using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IPLCharacterController2D: MonoBehaviour
{

    // add speed control
    [SerializeField]
    int speed;
    [SerializeField]
    int jumpForce;
    [SerializeField]
    Transform groundCheckA;
    [SerializeField]
    Transform groundCheckB;
    [SerializeField]
    LayerMask groundLayers;

    float horizontalSpeed;
    float jumpSpeed;

    bool isGrounded;
    bool isFlipped;

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
        CheckGround();
        CheckFlip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void CheckFlip()
    {
        if ((horizontalSpeed > 0.001f && isFlipped) || (horizontalSpeed < -0.001f && !isFlipped))
            UpdateFlip();
    }

    void UpdateFlip()
    {
        isFlipped = !isFlipped;
        float rotationAngle = isFlipped ? 180f : -180f;
        myTransform.Rotate(new Vector3(0f, rotationAngle, 0f), Space.Self);
    }

    void ReadInput()
    {
        horizontalSpeed = Input.GetAxis("Horizontal") * speed;
        jumpSpeed = Input.GetAxisRaw("Jump") * jumpForce;
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, groundLayers);
    }

    private void Move()
    {
        //        transform.Translate(new Vector2(horizontalSpeed, 0f));
        bool shouldJump = (jumpSpeed > 0f) && isGrounded;
        float yVelocity = shouldJump ? jumpSpeed : myRigidbody.velocity.y;
        myRigidbody.velocity = new Vector2(horizontalSpeed, yVelocity);
    }
}
