
using UnityEngine;

// Controls player movement on the XZ plane using physics.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Editable movement speed

    private Rigidbody rb;
    private int score = 0; // Initialize score to 0

    // Called once at the beginning
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called on a fixed interval for physics updates
    private void FixedUpdate()
    {
        // Get input for horizontal (A/D or Left/Right) and vertical (W/S or Up/Down)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create movement vector only in X and Z axes
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        // Apply the movement while maintaining physics stability
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    // Trigger event handler for pickups
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false); // Disable the coin
        }
    }
}
