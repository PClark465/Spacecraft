using UnityEngine;
using UnityEngine.InputSystem;

// Sub class of Pawn
public class PawnSpacecraft : Pawn
{
    // Variables of speed that affect movement and turning, use these values as default for now
    public float moveSpeed = 3;
    public float turnSpeed = 180;
    
    // Start is called once before the first execution of Update after Pawn is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Overrides the parent class for moving
    public override void Move (Vector3 moveVector)
    {
        transform.position += moveVector * moveSpeed * Time.deltaTime;       // Moves position based on the Vector, adds moveVector to my position and storing it
    }

    // Overrides parent class for rotating
    public override void Rotate (float angle)   // Floating point value for the angle, adds 'angle' and stores it
    {
        transform.Rotate (0,0,angle * turnSpeed * Time.deltaTime);       // Rotates based on the angle, Z-axis only
    }
}

/*
    Incorporate Time.deltaTime in order to affect the speed of movement
*/

/*
    Make sure sprite has this script component, along with ControllerPlayer script under 'Controller' element
*/