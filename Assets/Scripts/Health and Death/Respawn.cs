using UnityEngine;

public class Respawn : Death
{
    public override void Die()
    {
        // Tell GameManager that player died
        if(GameManager.instance != null)
        {
            GameManager.instance.PlayerDied();
            if(GameManager.instance.remainingLives <= 0)
            {
                return;
            }
        }
        
        // Get health component
        Health ourHealth = GetComponent<Health>();
        // If it exists, set our health back to max and set to origin
        if(ourHealth != null)
        {
            ourHealth.currentHealth = ourHealth.maxHealth;
            if(ourHealth.healthBar != null)
            {
                ourHealth.healthBar.fillAmount = 1f;
            }
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