using UnityEngine;
using System.Collections;

public class RandomMeteorMovement : MonoBehaviour
{
    // Adjustable settings for the screen wrapping buffer and speed of the meteors as they move
    [Header("Movement Settings")]
    public float minSpeed = 1f;
    public float maxSpeed = 4f;

    [Header("Acceleration Settings")]
    public float speedIncrease = 0.5f;
    public float increaseInterval = 5f;
    public int maxIncreases = 10;
    public float maximumSpeed = 8f;

    [Header("Screen Wrapping")]
    public float wrapBuffer = 0.5f;

    private Rigidbody2D rb;
    private Camera mainCamera;

    private Vector2 moveDirection;
    private float currentSpeed;
    
    // Grab the rigidbody component and camera before even running the script
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDirection = Random.insideUnitCircle.normalized;

        // If vector.zero
        if (moveDirection == Vector2.zero)
        {
            moveDirection = Vector2.right;
        }

        currentSpeed = Random.Range(minSpeed, maxSpeed);

        rb.gravityScale = 0f;
        rb.linearDamping = 0f;
        rb.linearVelocity = moveDirection * currentSpeed;

        StartCoroutine(IncreaseSpeedOverTime());
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        for(int i = 0; i < maxIncreases; i++)
        {
            // Wait for speed increase
            yield return new WaitForSeconds(increaseInterval);

            // Increase speed without exceeding limit
            currentSpeed = Mathf.Min(
                currentSpeed + speedIncrease,
                maximumSpeed
            );

            // Apply new velocity
            rb.linearVelocity = moveDirection * currentSpeed;

            // Stop for loop if maximumSpeed is reached
            if(currentSpeed >= maximumSpeed)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mainCamera == null)
        {
            return;
        }
        
        // Calculates camera boundaries
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        Vector3 cameraPosition = mainCamera.transform.position;

        float left = cameraPosition.x - halfWidth;
        float right = cameraPosition.x + halfWidth;
        float bottom = cameraPosition.y - halfHeight;
        float top = cameraPosition.y + halfHeight;
        
        Vector2 position = rb.position;

        // Vertical wrapping
        if(position.y > top + wrapBuffer)
        {
            position.y = bottom - wrapBuffer;
        }
        else if(position.y < bottom - wrapBuffer)
        {
            position.y = top + wrapBuffer;
        }

        // Horizontal wrapping
        if(position.x > right + wrapBuffer)
        {
            position.x = left - wrapBuffer;
        }
        else if(position.x < left - wrapBuffer)
        {
            position.x = right + wrapBuffer;
        }

        // Teleport without velocity change
        if(position != rb.position)
        {
            rb.position = position;
        }

    }
}
