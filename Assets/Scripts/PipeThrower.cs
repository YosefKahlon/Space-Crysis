using UnityEngine;

public class PipeThrower : MonoBehaviour
{
    public float throwForce = 3f;
    [SerializeField] Transform ExitPipe;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision was with the astronaut
        if (collision.gameObject.CompareTag("Player"))
        {
            float impactStrength = collision.relativeVelocity.magnitude;
            // Debug.Log("Got Collision");

            // Calculate the throw direction and apply force to the astronaut
            Vector2 throwDirection = ExitPipe.position - transform.position; // use the pipe's right direction
            collision.gameObject.transform.position = ExitPipe.position; // Teleport to other side of pipe
            // Debug.Log("Direction Vector " + throwDirection);
            
            // Force applied on player when exit the pipe
            Vector3 exitPipeForce = throwDirection * impactStrength * throwForce;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(exitPipeForce, ForceMode2D.Impulse);
        }
    }   
}
