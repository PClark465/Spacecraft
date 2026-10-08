using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    //Declare variables, in this case the Sprite Renderer to adjust color and scale
    public SpriteRenderer spacecraftTransformer;

    //Initialization of the code
    //Void allows for me to teach the computer how to do something
    void Start()
    {
        //Change the scale and color of the spacecraft sprite
        spacecraftTransformer.color = Color.blue;   //Color change
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
// Create several separate example codes and explain what each does for retention purposes
// Will leave in this project, each code will pertain to the concepts learned, should make folder for dedicated scripts

/*
    1. Create repo on browser, use Unity gitignore
    2. Clone to GitHub desktop, make sure you have access token
    3. Move all files into Repo folder in file explorer
    4. Create Unity project using GitHub source control
    5. Create branches if necessary for merging
*/

//Public means that it can be used elsewhere in the code
//Class: classification or type of thing
//Start runs automatically when creating the object, before updates

/*
    1. Build profiles
    2. Scene list
    3. File location (DONT PUT INTO PROJECT)
*/

//Vector focuses on movement in this current library of C#
