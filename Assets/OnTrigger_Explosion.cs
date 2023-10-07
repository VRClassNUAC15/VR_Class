using UnityEngine;

public class OnTrigger_Explosion : MonoBehaviour // Name of the class and script         
{
    public GameObject explosion;                 // Declaring a variable
    public Transform locationExplode;            // Where the explosion will be created

    private void OnTriggerEnter(Collider other)  // When my trigger is hit...
    {
        if (other.name.Contains("Controller"))   // ...and what hit me has in its name 'Controller'...
        {
            Explode();                           // ...run the Explode function.
        }
    }
    private void Explode()
    {
        // Create a new explosion right where this script's gameobject is
        GameObject newExplosion = GameObject.Instantiate(explosion, locationExplode);
        Destroy(newExplosion, 2.0f);             // Destroy this new explosion in 2 seconds
    }
}
