using UnityEngine;

public class MeteorHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function for taking damage as your character
    public void TakeDamage( float damage )
    {
        // Subtract damage from current health, if current health is less than zero, tell pawn to die
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}
