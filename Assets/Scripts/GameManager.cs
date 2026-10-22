using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Obstacle> obstacleList;

    private bool hasLogged = false;

    void Awake ()
    {
        obstacleList = new List<Obstacle>();
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Prevents the game manager object from being destroyed
        }
        else 
        {
            Destroy(gameObject);    // Destroys game manager only if instance is no longer null
        }
    }


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(obstacleList != null)
        {
            if(obstacleList.Count <= 0 && !hasLogged)
            {
                Debug.Log("Victory");
                hasLogged = true;
            }
        }
    }
}

/*
    This script is to show the Singleton Pattern in action
    It takes into account if there is already a game manager that exists, destroys any other instances of a game manager if it exists
*/