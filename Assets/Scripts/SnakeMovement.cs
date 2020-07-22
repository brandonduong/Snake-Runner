using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject stats;
    public int followDistance;
    private List<Vector3> storedPositions;
    public GameObject segmentRemains;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = GameObject.FindGameObjectWithTag("GameController");
        storedPositions = new List<Vector3>(); // Creates a blank list

        // Create space between all segments
        followDistance = followDistance * stats.GetComponent<GameManager>().foodEaten;
    }

    void Update()
    {
        // If player dead, do nothing
        if (!player)
        {
            Break();
            return;
        }

        // Store starting position
        if (storedPositions.Count == 0)
        {
            storedPositions.Add(player.transform.position); //store the players currect position
            return;
        }

        // If position changes, store it
        else if (storedPositions[storedPositions.Count - 1] != player.transform.position)
        {
            storedPositions.Add(player.transform.position); //store the position every frame
        }

        // Once delay is reached, move
        if (storedPositions.Count > followDistance)
        {
            transform.position = storedPositions[0];
            storedPositions.RemoveAt(0);
        }
    }

    void Break()
    {
        Instantiate(segmentRemains, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}