
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip triggerSound;

    private bool hasPlayed = false; // Variable to check whether the sound was played or not

    // The method is called when the character enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // If there is sound, play it once
            if (audioSource != null && triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound);
            }

            // Set the flag to play the sound only once
            hasPlayed = true;
        }
    }
}
