using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Reference to transform to do some position/rotation checks
    public Transform[] spawnPoints;

    public GameObject obstacle;
    public GameObject zigzag;
    public GameObject slide;

    public int obstaclesNum = 4;

    // Time to spawn first obstacle wave
    float timeToSpawn = 0f;

    // Time to spawn next obstacle wave
    float timeBetweenSpawns = 1f;

    // Some obstacle sets need extra time to complete
    private float timeBetweenSpawnsAdder;

    // Extra time obstacle sets need
    float timeBetweenWalls = 0f;

    float timeBetweenZigZags = 0.5f;
    
    float timeBetweenSlides = 1f;

    // Speedup intervals
    public float speedupIntervals = 5f;
    int speedLevel = 0;
    public Vector3 speedup;
    Vector3 baseSpeed;

    void Awake()
    {
        baseSpeed = obstacle.GetComponent<ApproachingObstacleMovement>().baseForwardSpeed;
    }

    void Update()
    {
        // Time.time = amount of time passed since start of game
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            // Randomly create an obstacle
            int randomNum = Random.Range(0, obstaclesNum);

            Debug.Log(randomNum);

            switch (randomNum)
            {
                case 0:
                    SpawnWall();
                    break;

                case 1:
                    SpawnZigZag();
                    break;

                case 2:
                    SpawnSlideRight();
                    break;

                case 3:
                    SpawnSlideLeft();
                    break;
            }

            timeToSpawn = Time.timeSinceLevelLoad + timeBetweenSpawns + timeBetweenSpawnsAdder;
        }

        if (Time.timeSinceLevelLoad >= speedupIntervals * speedLevel)
        {
            speedLevel += 1;
        }

        foreach (ApproachingObstacleMovement i in FindObjectsOfType<ApproachingObstacleMovement>())
        {
            i.constantForwardSpeed = baseSpeed + (speedup * speedLevel);
        }
    }

    void SpawnWall()
    {
        int randomNum = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomNum)
            {
                // Quaternion.identity = do no rotation
                Instantiate(obstacle, spawnPoints[i].position, Quaternion.identity);
            }
        }

        timeBetweenSpawnsAdder = timeBetweenWalls;
    }

    void SpawnZigZag() {
        Instantiate(zigzag, spawnPoints[0].position + zigzag.transform.position, Quaternion.identity);

        timeBetweenSpawnsAdder = timeBetweenZigZags;
    }

    void SpawnSlideRight()
    {
        Instantiate(slide, spawnPoints[0].position + slide.transform.position, Quaternion.identity);

        timeBetweenSpawnsAdder = timeBetweenSlides;
    }

    void SpawnSlideLeft()
    {
        Instantiate(slide, spawnPoints[0].position + slide.transform.position + new Vector3(-4, 0, 0), Quaternion.Euler(0f, 0f, 180f));

        timeBetweenSpawnsAdder = timeBetweenSlides;
    }
}
