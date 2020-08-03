using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 2)
        {
            Menu();
            return;
        }

        // Load next scene in queue (Presumably the next level)
        FindObjectOfType<FadeInOut>().FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(FindObjectOfType<AudioManager>().gameObject);
    }

    public void Menu()
    {
        FindObjectOfType<FadeInOut>().FadeToScene("Menu");
        Destroy(FindObjectOfType<AudioManager>().gameObject);
    }
}
