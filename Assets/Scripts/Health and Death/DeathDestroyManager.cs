using UnityEngine;

public class DeathDestroyManager : Death
{
    public int scoreValue;

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

            GameManager.instance.score += scoreValue;
            GameManager.instance.SpawnEnemy();
        }
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