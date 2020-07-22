using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Get the transform component of the player object
    public Transform player;

    // Stores 3 floats for position
    public Vector3 offset;
    Vector3 offsetCopy;

    public GameManager gameManager;

    // Base camera rotation (when food eaten = 0)
    public float baseCameraRotation = 5f;

    // How much to rotate the camera by for each snake segment
    public float cameraRotateUpdate = 2.5f;

    public float maxRotate;

    public float offsetMultiplier = 10f;

    private void Start()
    {
        offsetCopy = offset;
    }

    // Update is called once per frame
    void Update()
    {
        // Only follow if player isn't destroyed
        if (player)
        {
            int foodEaten = gameManager.foodEaten;

            // Dealing with smooth camera changes
            Vector3 maxOffset = offsetCopy * ((foodEaten / offsetMultiplier) + 1);
            float maxRotation = baseCameraRotation + (cameraRotateUpdate * foodEaten);

            // If level has been beaten, zoom out camera to show all segments!
            if (gameManager.gameWin)
            {
                maxOffset = offsetCopy * ((foodEaten / (offsetMultiplier / 2)) + 1);
                maxRotation = 90f;
                maxRotate = 90f;
            }

            if (offset.y <= maxOffset.y)
            {
                offset.y += 0.01f;
            }

            if (offset.z >= maxOffset.z)
            {
                offset.z -= 0.01f;
            }

            transform.position = player.position + offset;

            Vector3 rotation = transform.eulerAngles;
            if (rotation.x <= maxRotation)
            {
                rotation.x += 0.01f;
            }

            if (rotation.x >= maxRotate)
            {
                rotation.x = maxRotate;
            }

            transform.eulerAngles = rotation;
        }
        
    }
}
