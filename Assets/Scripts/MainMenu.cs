using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        AudioManager.instance.PlaySound("menuSong");
    }

    public void QuitGame()
    {
        FindObjectOfType<FadeInOut>().FadeToScene("");
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
