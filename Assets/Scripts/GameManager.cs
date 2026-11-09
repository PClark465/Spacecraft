using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Obstacle> obstacleList;

    private bool hasLogged = false;

    public int score;

    public TMP_Text text;

    private float spawnChance;

    public GameObject bigMeteorPrefab;
    public GameObject ufoPrefab;
    public GameObject meteorPrefab;

    public GameObject gameOverPanel;
    private bool isGameOver = false;

    [Header("Enemy Spawning")]
    public int startingEnemyCount;

    [Header("Scoring Setting")]
    public int winningScore = 1000;

    [Header("Player Lives")]
    public int startingLives = 3;
    public int remainingLives;

    void Awake ()
    {
        obstacleList = new List<Obstacle>();
        
        if(instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);  // Prevents the game manager object from being destroyed
        }
        else 
        {
            Destroy(gameObject);    // Destroys game manager only if instance is no longer null
        }
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        for(int i = 0; i < startingEnemyCount;i++)
        {
            SpawnEnemy();
        }
        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        remainingLives = startingLives;
    }

    // Update is called once per frame
    void Update()
    {
       // If list empties, log victory into console, no longer needed
       if(obstacleList != null)
        {
            if(obstacleList.Count <= 0 && !hasLogged)
            {
                Debug.Log("Victory");
                hasLogged = true;
            }
        }

        // Check for score count
        if(text != null)
        {
            text.text = "" + score;
        }

        // Check victory condition
        if(score >= winningScore && !isGameOver)
        {
            Victory();
        }

    }

    // Spawn Enemy function
    public void SpawnEnemy()
    {
        spawnChance = Random.Range(1, 100);
        Vector3 randomSpawnPosition = Vector3.zero;
        randomSpawnPosition.x = Random.Range(-20f, 20f);
        randomSpawnPosition.y = Random.Range(-4.5f, 4.5f);
        
        if(isGameOver)
        {
            return;
        }
        
        // Takes into account the random number, invert order
        if(spawnChance <= 20)
        {
            // Quaternion used to prevent rotation of sprite
            Instantiate(ufoPrefab, randomSpawnPosition, Quaternion.identity);
        }
        else if(spawnChance <= 50)
        {
            Instantiate(bigMeteorPrefab, randomSpawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(meteorPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }

    public void Victory()
    {
        if(isGameOver)
        {
            return;
        }
        isGameOver = true;
        Debug.Log("Victory, 1000 points");
        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        StopEnemyAudio();
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        // Checks to see if the game has ended
        if(isGameOver)
        {
            return;
        }

        isGameOver = true; // Sets to true 
        Debug.Log("Game Over");

        if(gameOverPanel != null)   // Show game over panel
        {
            gameOverPanel.SetActive(true);
        }
        StopEnemyAudio();
        Time.timeScale = 0f; // This pauses gameplay
    }
    
    //Function for restarting the game
    public void RestartGame()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        score = 0;
        isGameOver = false;
        hasLogged = false;

        obstacleList.Clear();

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    // Function for returning to the main menu
    public void ReturnToMainMenu()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        score = 0;
        isGameOver = false;
        hasLogged = false;

        obstacleList.Clear();
        SceneManager.LoadScene("MainMenu");
    }

    // Dictionary created for storing enemy score values
    private Dictionary<EnemyType, int> enemyScores =
        new Dictionary<EnemyType, int>()
    {
        { EnemyType.Meteor, 10 },
        { EnemyType.BigMeteor, 25 },
        { EnemyType.UFO, 50 }
    };

    // Method used to award points based on the type of enemy destroyed
    public void AwardEnemyPoints(EnemyType enemyType)
    {
        if(enemyScores.TryGetValue(enemyType, out int points))
        {
            score += points;
            if (score >= winningScore)
            {
                Victory();
            }
            else
            {
                SpawnEnemy();
            }
        }

    }

    // Creates a list of active enemies into the console window
    public void CountActiveEnemies()
    {
        int meteorCount = 0;
        int bigMeteorCount = 0;
        int ufoCount = 0;

        // Examine every enemy in obstacle list
        foreach (Obstacle obstacle in obstacleList)
        {
            if (obstacle == null)
                continue;

            DeathDestroyManager enemy =
                obstacle.GetComponent<DeathDestroyManager>();

            if (enemy == null)
                continue;

            // Count enemies based on type
            switch (enemy.enemyType)
            {
                case EnemyType.Meteor:
                    meteorCount++;
                    break;

                case EnemyType.BigMeteor:
                    bigMeteorCount++;
                    break;

                case EnemyType.UFO:
                    ufoCount++;
                    break;
            }
        }

        Debug.Log(
            "Meteors: " + meteorCount +
            " | Big Meteors: " + bigMeteorCount +
            " | UFOs: " + ufoCount
        );
    }

    // Function for counting player lives
    public void PlayerDied()
    {
        if (isGameOver)
            return;

        remainingLives--;
        if (remainingLives <= 0)
        {
            GameOver();
        }
    }

    // Method for making sure music audio keeps playing
    public void StopEnemyAudio()
    {
        foreach (Obstacle obstacle in obstacleList)
        {
            if (obstacle == null)
                continue;

            AudioSource[] enemyAudioSources =
                obstacle.GetComponentsInChildren<AudioSource>();

            foreach (AudioSource source in enemyAudioSources)
            {
                source.Stop();
            }
        }
    }

}

/*
    This script is to show the Singleton Pattern in action
    It takes into account if there is already a game manager that exists, destroys any other instances of a game manager if it exists
*/

/*
    In void Update():
    if(obstacleList.Count <= 0 && controllerPlayer != null)
    {
        if (controllerPlayer.pawn != null)
        {
            Debug.Log("Victory");
        }
    }
    if (controllerPlayer != null)
    {
        if (controllerPlayer.pawn == null)
        {
            Debug.Log("Try Again");
        }
    }

    For establishing win/fail condition
*/

// "" + score; -> this is for converting the score into a readable numeric string value

/*
    Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    // Atan2 - arctan
*/