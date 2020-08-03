using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
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
}
