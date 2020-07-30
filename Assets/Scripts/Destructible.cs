// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion; // Reference to the shattered version of the object

    // Called whenever current objects collides with something (Needs a rigid boy + collider)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            // Spawn a shattered object
            Instantiate(destroyedVersion, transform.position, transform.rotation);

            // Remove the current object
            Destroy(gameObject);
        }
	}

}
