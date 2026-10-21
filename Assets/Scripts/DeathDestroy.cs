using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        // Do what ALL death components do
        base.Die();

        // Destroy this object, removes from game
        Destroy(gameObject);
    }
}

/*
    override - allows the child class to override the parent class

    (this.gameObject); is the same as (gameObject);

    base.Die(); calls back to parent class
*/

/*
    public float explosionForce
    public float explosionDistance  --> more advanced metrics that can be used in building death scripts
*/