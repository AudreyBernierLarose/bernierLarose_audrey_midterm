using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Private variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private Animator anim;
    private bool isFacingRight = true;
    private Vector3 startPos;
    private bool isDucking;

    //"Public" variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        startPos = gameObject.transform.position;
    }

    //When working with physics, use FixedUpdate Loop
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump code goes here!
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Check if the sprite needs to be flipped
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
            Flip();

        if (transform.position.y < -20)
            gameObject.transform.position = startPos;

        //Communicate with animator
        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("ySpeed", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDucking", isDucking);

        Duck();
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    private void Duck()
    {
        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            anim.SetBool("isDucking", !isDucking);
            if (rBody.velocity.x != 0)
                anim.SetBool("isDucking", isDucking);
        }
        else
            anim.SetBool("isDucking", isDucking);
    }
}
