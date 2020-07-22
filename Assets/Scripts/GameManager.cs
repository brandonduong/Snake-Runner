using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float restartDelay = 4f;
    public bool gameOver = false;
    public bool gameWin = false;
    public int foodEaten = 0;

    public GameObject levelCompleteUI;

    public void FoodEaten()
    {
        foodEaten += 1;
        Debug.Log("Eaten " + foodEaten.ToString() + " food.");
    }

    public void EndGame()
    {
        if (!gameOver)
        {
            // Reset current level
            gameOver = true;
            Invoke("Restart", restartDelay);
        }
        
    }

    public void WinGame()
    {
        Debug.Log("Level won");
        gameWin = true;

        // Pops up the level complete screen
        levelCompleteUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
