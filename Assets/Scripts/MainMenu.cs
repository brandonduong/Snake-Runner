using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load next scene in queue
        SceneManager.LoadScene("LevelSelect");
    }

    public void InfiniteGame()
    {
        // Load infinite mode scene
        SceneManager.LoadScene("LevelInf");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
