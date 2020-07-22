using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameManager gameManager;
    public int foodScore;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            // If game has been won, stop updating score
            if (gameManager.gameWin)
            {
                return;
            }

            if (SceneManager.GetActiveScene().name != "LevelInf")
            {
                // Display score ("0") for 0 decimals
                scoreText.text = (player.position.z + (foodScore * gameManager.foodEaten)).ToString("0");
            }

            else
            {
                scoreText.text = (Time.timeSinceLevelLoad + (gameManager.foodEaten)).ToString("0");
            }
            
        }
    }
}
