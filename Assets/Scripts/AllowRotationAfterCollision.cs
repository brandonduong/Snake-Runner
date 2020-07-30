using UnityEngine;

public class AllowRotationAfterCollision : MonoBehaviour
{
    public Rigidbody rb;

    // Called whenever current objects collides with something (Needs a rigid boy + collider)
    void OnCollisionEnter(Collision collision)
    {
        if (!FindObjectOfType<GameManager>().gameOver && collision.collider.tag != "DeathFloor" && collision.collider.tag != "Ground")
        {
            // Allow model to ragdoll after loss
            rb.freezeRotation = false;
            rb.AddExplosionForce(10f, rb.position, 10f);
        }
    }
}
