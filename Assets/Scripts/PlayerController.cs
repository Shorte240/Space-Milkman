using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float movementSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
	Vector3 playerPosition;

    public AudioSource jump;
    public AudioSource doubleJump;

    private bool doubleJumped;
    
	// Use this for initialization
	void Start ()
    {
        
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isGrounded)
        {
            doubleJumped = false;
        }

	    if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            jump.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !isGrounded)
        {
            Jump();
            doubleJumped = true;
            doubleJump.Play();
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -movementSpeed;
        }

        // Broken flipping code
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // End

        if (Input.GetKeyDown(KeyCode.Backspace))
		{
			FindObjectOfType<LevelManager> ().RespawnPlayer ();
		}

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Player stick to the platform
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.name == "platform")
		{
			gameObject.transform.SetParent (other.gameObject.transform);
		}
	}

    // Unstick from platform
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.name == "platform")
		{
			gameObject.transform.SetParent (null);
		}
	}

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}