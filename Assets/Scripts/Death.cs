using UnityEngine;

public class Death : MonoBehaviour
{
    public virtual void Die()
    {
        // This happens when the object dies
        Debug.Log("Try again");
    }
}

/*
    virtual - allows the variable to be overridden
*/