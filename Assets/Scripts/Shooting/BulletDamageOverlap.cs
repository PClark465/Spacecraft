using UnityEngine;

public class BulletDamageOverlap : MonoBehaviour
{
    public float bulletDamageDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function meant to check for triggers that were made
    public void OnTriggerEnter2D( Collider2D otherCollider )
    {
        Health otherHealth;
        // Get health component from other object
        otherHealth = otherCollider.gameObject.GetComponent<Health>();
        // Does health component exist or maybe object doesn't have health
        if(otherHealth != null && otherCollider.gameObject.CompareTag("Enemy"))
        {
            // Tell health component to take damage
            otherHealth.TakeDamage( bulletDamageDone ); 
        }
    }
}
