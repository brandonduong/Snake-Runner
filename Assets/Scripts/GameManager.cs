using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameWin = false;
    public int foodEaten = 0;

    public GameObject levelCompleteUI;
    public GameObject levelFailedUI;
    public GameObject foodEatenUpUI;

    public void FoodEaten()
    {
        foodEaten += 1;
        foodEatenUpUI.SetActive(true);
        Invoke("HideFoodUpUI", 0.5f); // Delay is in seconds
        Debug.Log("Eaten " + foodEaten.ToString() + " food.");
    }

    public void HideFoodUpUI()
    {
        foodEatenUpUI.SetActive(false);
    }

    public void EndGame()
    {
        if (!gameOver)
        {
            // Reset current level
            gameOver = true;
            levelFailedUI.SetActive(true);
        }
        
    }

    public void WinGame()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled)
        {
            return;
        }

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
