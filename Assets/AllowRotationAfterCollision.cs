using UnityEngine;

public class AllowRotationAfterCollision : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called whenever current objects collides with something (Needs a rigid boy + collider)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "DeathFloor" && collision.collider.tag != "Ground")
        {
            // Allow model to ragdoll after loss
            rb.freezeRotation = false;
            rb.AddExplosionForce(10f, rb.position, 10f);
        }
    }
}
