using System;
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
    [SerializeField]
    Animator animator;

    [SerializeField]
    bool moveInWorldSpace;

    float horizontalSpeed;
    float jumpSpeed;
    bool isGrounded;
    bool isFlipped;

    Transform myTransform;
    Rigidbody2D myRigidbody;

    float horizontalInput;
    float jumpInput;
    public float HorizontalInput { get => horizontalInput; set => horizontalInput = value; }
    public float JumpInput { get => jumpInput; set => jumpInput = value; }


    // Start is called before the first frame update
    void Start()
    {
        this.HorizontalInput = 1f;  
        myTransform = transform;
        isFlipped = myTransform.right.x < 0;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        CheckGround();
        CheckFlip();
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalSpeed));
        animator.SetFloat("VerticalSpeed", myRigidbody.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
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
      horizontalSpeed = horizontalInput * speed;
      if (!moveInWorldSpace)
        horizontalSpeed = horizontalSpeed * Mathf.Sign(myTransform.right.x);
      jumpSpeed = jumpInput * jumpForce;
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, groundLayers);
    }

    private void Move()
    {
        bool shouldJump = (jumpSpeed > 0f) && isGrounded;
        float yVelocity = shouldJump ? jumpSpeed : myRigidbody.velocity.y;
        myRigidbody.velocity = new Vector2(horizontalSpeed, yVelocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundCheckA.position, new Vector2(groundCheckB.position.x, groundCheckA.position.y));
        Gizmos.DrawLine(new Vector2(groundCheckB.position.x, groundCheckA.position.y), groundCheckB.position);
        Gizmos.DrawLine(groundCheckB.position, new Vector2(groundCheckA.position.x, groundCheckB.position.y));
        Gizmos.DrawLine(new Vector2(groundCheckA.position.x, groundCheckB.position.y), groundCheckA.position);
    }
}
