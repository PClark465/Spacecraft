using UnityEngine;

public class Health : MonoBehaviour
{
    // Establish variables for what health should consist of
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
            Die();
        }
    }

    // Function for death of character
    public void Die()
    {
        Debug.Log("Try again.");
    }
}

/*
    Remember: always follow the logic of wondering what inputs are needed to produce outputs
    Make sure these inputs and outputs are as abstract and simple as possible
    Easier code to read = better
*/

/*
    // Function for healing health
    public void Heal ( float healAmount )
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
*/

/*
    // Returns the percent value of health, allows the variables of currentHealth and maxHealth to be set to private
    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }
*/

/*
    - [HideInInspector] = public
    - [SerializeField] = private
        // To show up in the inspector window in Unity
*/