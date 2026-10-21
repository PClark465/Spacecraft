using UnityEngine;

public class DeathDestroyManager : Death
{
    private Obstacle obstacleToRemoveOnDeath;

    void Start()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    public override void Die()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.obstacleList != null)
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath);
            }
        }
        Destroy(gameObject);
    }
}
