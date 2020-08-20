using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f;
    public float jumpForce = 500f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    private Rigidbody2D rigidbody;
    public bool isGrounded = false;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        UnityEngine.Vector2 movement = new UnityEngine.Vector2(deltaX, rigidbody.velocity.y);
        rigidbody.velocity = movement;
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidbody.AddForce(new UnityEngine.Vector2(0f, jumpForce));
        }
        
    }
}
