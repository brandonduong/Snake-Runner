using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    // Reference to created prefab
    public GameObject segment;


    // Called whenever current objects collides with something (Needs a rigid boy + collider)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player hit food!");
            FindObjectOfType<GameManager>().FoodEaten();
            Destroy(gameObject);

            // Create 1 segment of snake
            Instantiate(segment, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
