using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rb;

    public GameObject remains;
    bool hit;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        hit = false;
    }

    // Called whenever current objects collides with something (Needs a rigid boy + collider)
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.tag == "Obstacle" || collision.collider.tag == "DeathFloor") && !hit)
        {
            Debug.Log("Hit obstacle!");

            // Play sound
            // gameObject.SendMessage("PlaySound", "playerHit");
            AudioManager.instance.PlaySound("playerHit");

            // Pops player up a bit after collision
            rb.AddExplosionForce(1000f, rb.position, 10f);

            // GetComponent<PlayerMovement>().enabled = false; // EQUIVALENT
            movement.enabled = false;

            // Allow model to ragdoll after loss
            rb.freezeRotation = false;

            hit = true;
        }

        if (!movement.enabled && collision.collider.tag == "Ground" || collision.collider.tag == "DeathFloor")
        {
            // Shatter
            Break();

            // Finds game manager and ends game if game hasn't been won already
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (!gameManager.gameWin)
            {
                gameManager.EndGame();
            }
        }
    }

    void Break()
    {
        Instantiate(remains, transform.position, transform.rotation);

        // Play sound
        // gameObject.SendMessage("PlaySound", "playerDeath");
        AudioManager.instance.PlaySound("playerDeath");

        Destroy(gameObject);
    }
}
