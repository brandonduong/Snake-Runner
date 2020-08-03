using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;

    bool exploded = false;
    public float blastRadius = 5f;
    public float explosionForce = 50f;

    void OnCollisionEnter(Collision collision)
    {
        if (exploded == false && collision.collider.tag == "Player")
        {
            Explode();
        }
    }

    void Explode()
    {
        exploded = true;
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, blastRadius);

        foreach(Collider nearbyObject in nearbyObjects)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }
        AudioManager.instance.PlaySound("bomb");
        Destroy(gameObject);
    }
}
