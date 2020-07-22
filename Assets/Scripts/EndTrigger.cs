using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        // If player triggers location, win game
        if (other.tag == "Player")
        {
            gameManager.WinGame();
        }
    }
}
