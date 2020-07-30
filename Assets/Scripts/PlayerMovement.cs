using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // A reference to the component, Rigidbody
    public Rigidbody rb;

    public bool moveLeft = false;
    public bool moveRight = false;
    public bool canJump = false;

    public float constantForwardSpeed;
    public float constantSidewaysSpeed;
    // public Vector3 jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }


    }

    // Update is called once per frame
    // Note: Use FixedUpdate for updates that invole calculating physics
    void FixedUpdate()
    {
        // Reads ALL horizontal keys
        float x = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * constantSidewaysSpeed;
        float z = Time.fixedDeltaTime * constantForwardSpeed;
        rb.MovePosition(rb.position + Vector3.right * x + Vector3.forward * z);
        
        // VelocityChange for constant speed
        // Vector3 velocityChange = constantForwardSpeed - new Vector3(0, 0, rb.velocity.z);
        // rb.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.VelocityChange);

        // Note: Time.deltaTime is the amount of seconds the computer drew the last frame
        /*
        if (moveRight)
        {
            // rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0); // * Time.deltaTime to ensure framerate does not affect speed of player
            // rb.MovePosition(rb.position + constantSidewaysSpeed);

            velocityChange = constantSidewaysSpeed - new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }*/

        /*
        else if (moveLeft)
        {
            // rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            // rb.MovePosition(rb.position - constantSidewaysSpeed);

            velocityChange = - constantSidewaysSpeed - new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }

        else
        {
            rb.AddForce(new Vector3(-rb.velocity.x, 0, 0), ForceMode.VelocityChange);
        }*/

        /*
        if (Input.GetKey("space") && canJump)
        {
            rb.AddForce(jumpForce);
            canJump = false;
        }
        */


    }

    private void OnCollisionEnter(Collision collision)
    {
        // Can only jump on the ground
        /*
        if (collision.collider.tag == "Ground")
        {
            canJump = true;
        }
        */
    }
}
