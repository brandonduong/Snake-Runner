using UnityEngine;

public class RandomSidewaysMovement : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    public Vector3 sidewaysSpeed;
    bool moveLeft;

    // Change direction if this boundary is crossed in the x direction
    public float leftRightBoundaries = 5.5f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        int randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
    }

    void FixedUpdate()
    {
        if (rb.position.x + tr.localScale.x / 2 >= leftRightBoundaries)
        {
            moveLeft = true;
        }

        else if ((-rb.position.x) + tr.localScale.x / 2 >= leftRightBoundaries)
        {
            moveLeft = false;
        }

        if (moveLeft)
        {
            // Have obstacles approach player at constant speed
            Vector3 velocityChange = - sidewaysSpeed - new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        else
        {
            // Have obstacles approach player at constant speed
            Vector3 velocityChange = sidewaysSpeed - new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
