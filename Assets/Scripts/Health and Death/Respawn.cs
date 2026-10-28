using UnityEngine;

public class Respawn : Death
{
    public override void Die()
    {
        // Get health component
        Health ourHealth = GetComponent<Health>();
        // If it exists, set our health back to max and set to origin
        if(ourHealth != null)
        {
            ourHealth.currentHealth = ourHealth.maxHealth;
        }

        Transform transformComponent;
        transformComponent = GetComponent<Transform>();
        transformComponent.position = Vector3.zero; // (randomSpawnPosition);

        Debug.Log("Try Again");
    }
}

// transform.position = Vector3.zero;   shorthand version

/*

*/