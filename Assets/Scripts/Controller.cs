using UnityEngine;
using UnityEngine.InputSystem;

// Super class of Controllers
public abstract class Controller : MonoBehaviour
{
    // Establishes pawns as to what controllers are affecting.
    public Pawn pawn;
}

// Remove Start and Update since this code will be the parent class