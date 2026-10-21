using UnityEngine;
using UnityEngine.InputSystem;

// Super class of the Pawns
public abstract class Pawn : MonoBehaviour
{
    // This variable establishes the behavior of which Pawns will respond to in terms of input
    public Controller controller;
    
    // Movement variables for rotation and moving
    public abstract void Move(Vector3 moveVector);
    public abstract void Rotate(float angle);
    public abstract void Teleport();
    public abstract void TurboMove(Vector3 moveVector);
    public abstract void Shoot();
}
// Remove Start and Update since this code will be the parent class

// public abstract void TurboMove(Vector3 moveVector);