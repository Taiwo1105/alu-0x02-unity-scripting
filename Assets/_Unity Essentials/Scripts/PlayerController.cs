using UnityEngine;

// Controls player movement on the XZ plane using physics and tracks score/health.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;      // Editable movement speed
    public int health = 5;          // Player health set to 5 in Inspector

    private Rigidbody rb;
    private int score = 0;          // Tracks collected pickups

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false); // Or use Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
    }
}

