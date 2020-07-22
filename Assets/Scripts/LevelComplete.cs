using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
        {
            SceneManager.LoadScene("Menu");
            return;
        }

        // Load next scene in queue (Presumably the next level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
