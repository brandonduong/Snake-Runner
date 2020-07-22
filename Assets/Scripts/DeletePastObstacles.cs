using UnityEngine;

public class DeletePastObstacles : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        // Get reference to player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy if behind player still playing
        if (player && player.transform.position.z > transform.position.z + 15)
        {
            Destroy(gameObject);
        }

        // Allow obstacles to travel further if player is dead in case player is pushed back after death
        else if (transform.position.z < -100)
        {
            Destroy(gameObject);
        }
    }
}
