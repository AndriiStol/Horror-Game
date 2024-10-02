using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Animator objectAnimator;
    public string animationTriggerName; // Trigger name for animation
    public AudioSource audioSource;
    public AudioClip triggerSound;

    // Variable to check if the trigger has been triggered
    private bool hasTriggered = false;

    // The method is called when the character enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check that the trigger is activated only when the character is collided with (by tag)
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // If there's an animation, run it
            if (objectAnimator != null && !string.IsNullOrEmpty(animationTriggerName))
            {
                objectAnimator.SetTrigger(animationTriggerName);
            }

            
            if (audioSource != null && triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound);
            }

            // Set the flag to trigger only once
            hasTriggered = true;
        }
    }


}
