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
    public GameObject penguin;
    public GameObject fish;
    public GameObject barrel;
    public GameObject largeWallL;
    public GameObject largeWallR;
    public GameObject bouncyBall;
    public GameObject movingWall;
    public GameObject movingFood;
    public GameObject foodSnake;

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

    float timeBetweenBalls = 0.5f;

    float timeBetweenMovingWalls = 0.5f;

    float timeBetweenFoodSnake = 2f;

    int numFish = 30;
    int fishOffset = -3;
    int minBouncyBalls = 5;
    int maxBouncyBalls = 10;
    int minMovingWalls = 3;
    int maxMovingWalls = 7;

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

                case 4:
                    SpawnPenguins();
                    break;

                case 5:
                    SpawnBarrels();
                    break;

                case 6:
                    SpawnLargeWallL();
                    break;

                case 7:
                    SpawnLargeWallR();
                    break;

                case 8:
                    SpawnBouncyBalls();
                    break;

                case 9:
                    SpawnMovingWalls();
                    break;

                case 10:
                    SpawnFoodSnake();
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
        int randomNum = Random.Range(1, spawnPoints.Length - 1);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomNum && i != randomNum + 1)
            {
                // Quaternion.identity = do no rotation
                Instantiate(obstacle, spawnPoints[i].position, Quaternion.identity);
            }
        }

        timeBetweenSpawnsAdder = timeBetweenWalls;
    }

    void SpawnZigZag() {
        Instantiate(zigzag, spawnPoints[3].position + zigzag.transform.position, Quaternion.identity);

        timeBetweenSpawnsAdder = timeBetweenZigZags;
    }

    void SpawnSlideRight()
    {
        Instantiate(slide, spawnPoints[3].position + slide.transform.position, Quaternion.identity);

        timeBetweenSpawnsAdder = timeBetweenSlides;
    }

    void SpawnSlideLeft()
    {
        Instantiate(slide, spawnPoints[3].position + slide.transform.position + new Vector3(-4, 0, 0), Quaternion.Euler(0f, 0f, 180f));

        timeBetweenSpawnsAdder = timeBetweenSlides;
    }

    void SpawnPenguins()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Quaternion.identity = do no rotation
            Instantiate(penguin, spawnPoints[i].position, Quaternion.Euler(-90f, 0f, 0f));
        }

        for (int i = 0; i < numFish; i++)
        {
            Instantiate(fish, spawnPoints[3].position + new Vector3(0, i, fishOffset), Quaternion.identity);
        }
    }

    void SpawnBarrels()
    {
        for (int o = 0; o < 3; o++)
        {
            Instantiate(barrel, spawnPoints[0].position + new Vector3(0, o * 4f, -5), Quaternion.identity);
            Instantiate(barrel, spawnPoints[1].position + new Vector3(0, o * 4f, 0), Quaternion.identity);
            Instantiate(barrel, spawnPoints[2].position + new Vector3(0, o * 4f, -5), Quaternion.identity);
            Instantiate(barrel, spawnPoints[3].position + new Vector3(0, o * 4f, 0), Quaternion.identity);
            Instantiate(barrel, spawnPoints[4].position + new Vector3(0, o * 4f, -5), Quaternion.identity);
            Instantiate(barrel, spawnPoints[5].position + new Vector3(0, o * 4f, 0), Quaternion.identity);
            Instantiate(barrel, spawnPoints[6].position + new Vector3(0, o * 4f, -5), Quaternion.identity);
        }
    }

    void SpawnLargeWallL()
    {
        Instantiate(largeWallL, spawnPoints[3].position + new Vector3(0, 1, 0), Quaternion.identity);
    }

    void SpawnLargeWallR()
    {
        Instantiate(largeWallR, spawnPoints[3].position + new Vector3(0, 1, 0), Quaternion.Euler(-90f, 0f, 0f));
    }

    void SpawnBouncyBalls()
    {
        timeBetweenSpawnsAdder = 0;

        for (int i = 0; i < Random.Range(minBouncyBalls, maxBouncyBalls); i++)
        {
            int randomNum = Random.Range(0, spawnPoints.Length);

            Instantiate(bouncyBall, spawnPoints[randomNum].position + new Vector3(0, (1f * i), 0 + (15 * i)), Quaternion.identity);
            
            // More balls = more time delay
            timeBetweenSpawnsAdder += timeBetweenBalls;
        }
    }

    void SpawnMovingWalls()
    {
        timeBetweenSpawnsAdder = 0;

        for (int i = 0; i < Random.Range(minMovingWalls, maxMovingWalls); i++)
        {
            int randomNum = Random.Range(0, spawnPoints.Length);

            Instantiate(movingWall, spawnPoints[randomNum].position + new Vector3(0, 0, 0 + (15 * i)), Quaternion.identity);
            Instantiate(movingFood, spawnPoints[randomNum].position + new Vector3(0, 0, 7.5f + (15f * i)), Quaternion.identity);

            timeBetweenSpawnsAdder += timeBetweenMovingWalls;
        }
    }

    void SpawnFoodSnake()
    {
        Instantiate(foodSnake, spawnPoints[3].position, Quaternion.identity);

        timeBetweenSpawnsAdder += timeBetweenFoodSnake;
    }
}
