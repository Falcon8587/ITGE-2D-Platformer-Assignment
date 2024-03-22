//using System.Collections;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    private float horizontal;
//    public float speed = 8f;
//    public float jumpingPower = 16f;
//    private bool isFacingRight = true;

//    public float coyotetime = 0.2f;
//    private float coyotetimecounter;

//    public float jumpBufferTime = 0.2f;
//    private float jumpBufferCounter;

//    private bool doubleJump;

//    private bool canDash = true;
//    private bool isDashing;
//    [SerializeField] private float dashingPower = 24f;
//    [SerializeField] private float dashingTime = 0.2f;
//    [SerializeField] private float dashingCooldown = 1f;

//    [SerializeField] private Rigidbody2D rb;
//    [SerializeField] private Transform groundCheck;
//    [SerializeField] private LayerMask groundLayer;

//    public bool dashpowerup = false;
//    public bool DoubleJumpPowerup = false; 

//    private void Update()
//    {
//        horizontal = Input.GetAxisRaw("Horizontal");

//        if (IsGrounded())
//        {
//            coyotetimecounter = coyotetime;
//        }
//        else
//        {
//            coyotetimecounter -= Time.deltaTime;
//        }

//        if (Input.GetButtonDown("Jump"))
//        {
//            jumpBufferCounter = jumpBufferTime;
//        }
//        else
//        {
//            jumpBufferCounter -= Time.deltaTime;
//        }

//        if (DoubleJumpPowerup == true)
//        {
//            if (coyotetimecounter > 0f && !Input.GetButton("Jump"))
//            {
//                coyotetimecounter = coyotetime;
//                doubleJump = false;
//            }
//            else { }

//            if (Input.GetButton("Jump"))
//            {
//                if (IsGrounded() || doubleJump)
//                {
//                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

//                    doubleJump = !doubleJump;
//                }
//            }
//        }
//        else
//        {
//            if (jumpBufferCounter > 0f && coyotetimecounter > 0f)
//            {
//                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
//                jumpBufferCounter = 0f;
//            }
//        }

//        if (dashpowerup == true)
//        {
//            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
//            {
//                StartCoroutine(Dash());
//            }
//        }

//        Flip();
//    }

//    private void FixedUpdate()
//    {
//        if (isDashing)
//        {
//            return;
//        }

//        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
//    }

//    private bool IsGrounded()
//    {
//        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
//    }

//    private void Flip()
//    {
//        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
//        {
//            Vector3 localScale = transform.localScale;
//            isFacingRight = !isFacingRight;
//            localScale.x *= -1f;
//            transform.localScale = localScale;
//        }

//    }

//    private IEnumerator Dash()
//    {
//        canDash = false;
//        isDashing = true;
//        float originalGravity = rb.gravityScale;
//        rb.gravityScale = 0f;
//        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
//        yield return new WaitForSeconds(dashingTime);
//        rb.gravityScale = originalGravity;
//        isDashing = false;
//        yield return new WaitForSeconds(dashingCooldown);
//        canDash = true;
//    }
//}


using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Vector2 boxsize;
    public float castDistance;

    private bool doubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private bool canDash = true;
    private bool isDashing;

    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    public bool dashpowerup = false;
    public bool DoubleJumpPowerup = false;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        
        //Coyote Time Check
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //Jump and Double Jump Check
        if (DoubleJumpPowerup == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (coyoteTimeCounter > 0f || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                    doubleJump = !doubleJump;
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            coyoteTimeCounter = 0f;
        }



        if (dashpowerup == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        {
            if (isDashing)
            {
                return;
            }

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;    
        }
        else 
        { 
            return false; 
        }  
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxsize);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
