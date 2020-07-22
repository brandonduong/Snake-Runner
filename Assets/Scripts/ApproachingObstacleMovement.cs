using UnityEngine;

public class ApproachingObstacleMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 constantForwardSpeed;
    public Vector3 baseForwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        baseForwardSpeed = constantForwardSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Have obstacles approach player at constant speed
        Vector3 velocityChange = constantForwardSpeed - new Vector3(0, 0, rb.velocity.z);
        rb.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    // Called whenever current objects collides with something (Needs a rigid boy + collider)
    void OnCollisionEnter(Collision collision)
    {
        if (FindObjectOfType<GameManager>().gameOver && collision.collider.tag != "Floor")
        {
            // Allow model to ragdoll after loss
            rb.freezeRotation = false;
        }
    }
}
