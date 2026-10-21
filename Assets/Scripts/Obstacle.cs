using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.obstacleList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
// This script is strictly used to add whatever game object has this script to the obstacle list indicated in the game manager