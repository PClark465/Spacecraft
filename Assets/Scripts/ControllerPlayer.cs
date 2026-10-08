using UnityEngine;
using UnityEngine.InputSystem;

// Sub class for the Controller class
public class ControllerPlayer : Controller
{
    // Declare Keys for the Update process for movement
    public Key moveForward;
    public Key moveBackward;
    public Key rotateRight;
    public Key rotateLeft;
    
    // Start is called once before the first execution of Update after Controller is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // All if statements below take into account keyboard key and what movement needs to be executed
        if(Keyboard.current[moveForward].isPressed)
        {
            // Moves Forward
            pawn.Move(pawn.transform.up);
        }
        if(Keyboard.current[moveBackward].isPressed)
        {
            // Moves Backward
            pawn.Move(-pawn.transform.up);
        }
        if(Keyboard.current[rotateRight].isPressed)
        {
            // Rotates Right
            pawn.Rotate(1);
        }
        if(Keyboard.current[rotateLeft].isPressed)
        {
            // Rotates Left
            pawn.Rotate(-1);
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