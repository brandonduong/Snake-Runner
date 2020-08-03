using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailed : MonoBehaviour
{
    public void RetryLevel()
    {
        // Load same scene
        FindObjectOfType<FadeInOut>().FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        FindObjectOfType<FadeInOut>().FadeToScene("Menu");
        Destroy(FindObjectOfType<AudioManager>().gameObject);
    }
}
