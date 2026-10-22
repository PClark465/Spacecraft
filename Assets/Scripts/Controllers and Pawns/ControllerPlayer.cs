using UnityEngine;
using UnityEngine.InputSystem;

// Sub class for the Controller class
public class ControllerPlayer : Controller
{
    // Declare Keys for the Update process for movement and shooting
    public Key moveForwardLocal;
    public Key moveBackwardLocal;
    public Key rotateRightLocal;
    public Key rotateLeftLocal;

    public Key teleportKey;

    public Key moveForwardWorld;
    public Key moveBackwardWorld;
    public Key moveRightWorld;
    public Key moveLeftWorld;

    public Key turboKey;

    public Key shootKey;
    
    // Start is called once before the first execution of Update after Controller is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // All if statements below take into account keyboard key and what movement needs to be executed
        // Local Space
        // ADD: Null check
        if(Keyboard.current[turboKey].isPressed)
        {
            if(Keyboard.current[moveForwardLocal].isPressed)
            {
                // Moves Forward at turbo speed
                pawn.TurboMove(pawn.transform.up);
            }
            if(Keyboard.current[moveBackwardLocal].isPressed)
            {
                // Moves Backward at turbo speed
                pawn.TurboMove(-pawn.transform.up);
            }
        }
        else
        {
            if(Keyboard.current[moveForwardLocal].isPressed)
            {
                // Moves Forward
                pawn.Move(pawn.transform.up);
            }
            if(Keyboard.current[moveBackwardLocal].isPressed)
            {
                // Moves Backward
                pawn.Move(-pawn.transform.up);
            }
        }
        
        if(Keyboard.current[rotateRightLocal].isPressed)
        {
            // Rotates Right
            pawn.Rotate(-1);
        }
        if(Keyboard.current[rotateLeftLocal].isPressed)
        {
            // Rotates Left
            pawn.Rotate(1);
        }

        // World space
         if(Keyboard.current[moveForwardWorld].isPressed)
        {
            // Moves Forward
            pawn.Move(Vector3.up);
        }
        if(Keyboard.current[moveBackwardWorld].isPressed)
        {
            // Moves Backward
            pawn.Move(-Vector3.up);
        }
         if(Keyboard.current[moveRightWorld].isPressed)
        {
            // Moves Right
            pawn.Move(Vector3.right);
        }
        if(Keyboard.current[moveLeftWorld].isPressed)
        {
            // Moves Left
            pawn.Move(-Vector3.right);
        }

        // Teleport key
        if(Keyboard.current[teleportKey].wasPressedThisFrame)
        {
            pawn.Teleport();
        }

        // Shooting key
        if(Keyboard.current[shootKey].wasPressedThisFrame)
        {
            pawn.Shoot();
        }

    }
}

/*
    1. Vector3, world movement      --> pawn.Move(Vector3.up);
    2. Transform, local movement    --> pawn.Move(pawn.transform.up);
*/

/*
    Create empty game object for the player controller and link the sprite to it in the inspector view
*/

/*
    To change the movement speed, incorporate Time.deltaTime
*/

// Normalize World movement vectors