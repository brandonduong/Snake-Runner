using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // Load next scene in queue
        FindObjectOfType<FadeInOut>().FadeToScene("LevelSelect");
    }

    public void InfiniteGame()
    {
        // Load infinite mode scene
        FindObjectOfType<FadeInOut>().FadeToScene("LevelInf");
    }

    public void QuitGame()
    {
        FindObjectOfType<FadeInOut>().FadeToScene("");
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
