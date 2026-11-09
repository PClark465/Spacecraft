using UnityEngine;

public class DeathDestroyManager : Death
{
    [Header("Scoring Values")]
    public EnemyType enemyType;

    private Obstacle obstacleToRemoveOnDeath;
    private bool hasDied = false;

    void Awake()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    public override void Die()
    {
        // Checks boolean of death to avoid extra points rewarded
        if(hasDied)
            return;

        hasDied = true;

        if(GameManager.instance != null)
        {
            // Removes obstacle from list when destroyed
            GameManager.instance.obstacleList.Remove(
                obstacleToRemoveOnDeath
            );
            GameManager.instance.CountActiveEnemies();
            // Adds points to the total score based on enemy
            GameManager.instance.AwardEnemyPoints(enemyType);

        }
        // Plays explosion audio
        if(GameAudio.instance != null)
        {
            GameAudio.instance.PlaySFXAtPoint(
                GameAudio.instance.boomEffect,
                transform.position
            );
        }
        Destroy(gameObject);
    }
}

/*
    Create Canvas element in hierarchy
    Render mode: Screen Space - Overlay
    Canvas Scaler: Screen size, Match = 0.5
    Add stretched components on top and bottom of canvas
    Window > 2D > Sprite Editor, for 9-slicing

    Text TextMeshPro - Score
*/