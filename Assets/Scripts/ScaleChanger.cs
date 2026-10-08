using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleChanger : MonoBehaviour
{
    //Creates the public variables growthKey and shrinkKey
    public Key growthKey = Key.E;
    public Key shrinkKey = Key.Q;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if the E "growthKey" key is pressed. If it is, run this loop
        if (Keyboard.current[growthKey].wasPressedThisFrame)
        {
            //This line allows for the spacecraft sprite to increase in size at random
            transform.localScale += new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
        }

        //Check to see if the Q "shirnkKey" key is pressed. If it is, run this loop instead
        if (Keyboard.current[shrinkKey].wasPressedThisFrame)
        {
            //Spacecraft sprite decreases in size a random amount
            transform.localScale -= new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
        }
    }
}

/*
    tf - this.gameObject.GetComponent<Transform>(); --> longer version of line 22
*/

/*
    transform.localScale += new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5)); -->Shorthand
*/

/*
    transform.localScale -= new Vector3(1,1,1);  -->Shorthand, no random
*/

/*
    Transform tf;   //Variable for holding the Transform component
    tf = GetComponent<Transform>();     //Store into tf
*/