using UnityEngine;
using UnityEngine.InputSystem;

public class DamageOnOverlap : MonoBehaviour
{
    // Variable, damageDone is a float value
    public float damageDone;
    
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
        if(otherHealth != null)
        {
            // Tell health component to take damage
            otherHealth.TakeDamage( damageDone );
        }

    }
}

/*
    Check Canvas shell for more details regarding trigger code
    Get into habit of utilizing pseudocode to plan out the logic of game
        - Use in personal projects

    Health otherHealth = otherCollider.gameObject.GetComponent<Health>(); shorthand version
*/