using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireForce;
    public float lifetime;
    
    private Rigidbody2D rb;
    private Transform tf;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get both transform and rigidbody components to check if they exist, fire bullet with a specific amount of speed if true
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        if(rb != null && tf != null)
        {
            rb.AddForce(tf.up * fireForce);
        }

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Define what the bullet should do when colliding with a trigger
    public void OnTriggerEnter2D( Collider2D otherCollider )
    {
        // Debug.Log("Hit" + otherCollider.gameObject.name);
        if(otherCollider.GetComponent<Border>() == null)
        {
            Destroy(gameObject);
        }
    }

}

// Line 31: defining a function
// Remember: Most of the time is spent defining things in code