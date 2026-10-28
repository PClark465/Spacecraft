using UnityEngine;
using System.Collections.Generic;

public class SpriteSeeker : MonoBehaviour
{
    // Set Variables for what target the sprite seeks and its movespeed
    public Transform target;
    public float moveSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(target == null)
        {
           GameObject player = GameObject.FindGameObjectWithTag("Player");
           if(player != null)
           {
                target = player.transform;
           }
           else
           {
                Debug.LogWarning("Could not find Player");
           }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        // Checks to see if target exists
        if(target == null) return;
        {
            // Move towards the target if found
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );
            Vector3 turnToTarget = target.position - transform.position;
            transform.up = turnToTarget;
        }
        if (target == null)
        {
            Debug.LogWarning(gameObject.name + " has NO TARGET!");
            return;
        }
        
    }
}
