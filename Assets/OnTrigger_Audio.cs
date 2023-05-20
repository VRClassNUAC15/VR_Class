using UnityEngine;

[RequireComponent(typeof(AudioSource))]                 // Ensure we have an audio source on this gameobject
public class OnTrigger_Audio : MonoBehaviour            // Name of the class and script
{
    AudioSource myAudio;                                // Declaring a variable 
    void Start()
    {
        myAudio = GetComponent<AudioSource>();          // Assigning a variable
    }
    private void OnTriggerEnter(Collider other)         // When my trigger is hit...
    {
        if (other.name.Contains("Controller"))        // ...and what hit me has in its name 'HandCollider'...
        {
            FlipAudioSwitch();                          // ...run the FlipAudiotSwitch function.                 
        }
    }
    private void FlipAudioSwitch()
    {
        if (myAudio.isPlaying)                          // If my audio is playing, turn it off
        {
            myAudio.Stop();
        }
        else
        {
            myAudio.Play();                             // Otherwise, turn it on
        }
    }
}
