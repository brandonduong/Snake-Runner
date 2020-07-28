using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public Animator animator;

    private string sceneToLoad;

    public void FadeToScene(string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (sceneToLoad.Length > 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        sceneToLoad = "";
    }
}
