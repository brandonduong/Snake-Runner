using UnityEngine;

public class DeletePastObstacles : MonoBehaviour
{
    public GameObject camera;

    private void Awake()
    {
        // Get reference to player
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy if behind player still playing
        if (camera && camera.transform.position.z > transform.position.z + 15)
        {
            Destroy(gameObject);
        }
    }
}
