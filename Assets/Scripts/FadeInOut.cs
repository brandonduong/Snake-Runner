using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public Animator animator;

    private string sceneToLoad;
    private int sceneToLoadIndex;

    public void FadeToScene(string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToScene(int sceneIndex)
    {
        sceneToLoadIndex = sceneIndex;
        sceneToLoad = "";
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (sceneToLoad.Length > 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene(sceneToLoadIndex);
        }

        sceneToLoad = "";
    }
}
