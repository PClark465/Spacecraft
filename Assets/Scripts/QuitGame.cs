using UnityEngine;
using UnityEngine.InputSystem;

// Establishes class
public class QuitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if the Escape key is pressed
        if(Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            Application.Quit();     // Quits application or game
        }
    }
}
// This script's purpose is to quit the game application whenever the Escape key is pressed