﻿using UnityEngine;

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

            // Play sound
            AudioManager.instance.PlaySound("eatFood");

            Destroy(gameObject);

            // Create 1 segment of snake
            Instantiate(segment, new Vector3(100, 0, -100), Quaternion.identity);
        }
    }
}
