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
}
