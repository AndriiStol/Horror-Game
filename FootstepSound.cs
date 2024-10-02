using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepAudioSource; 
    public AudioClip footstepClip;  // The sound of a single step
    public float footstepDelay = 0.5f;  // Delay between step sounds
    public float runMultiplier = 1.5f;  // Running acceleration multiplier

    private FirstPersonController fpc;  // Link to the character control script
    private bool isWalking = false;  // A flag indicating whether a player is walking
    private float timeSinceLastStep = 0f;  // Time since the last step

    private void Start()
    {
        fpc = GetComponent<FirstPersonController>();  // Getting the character control script
    }

    private void Update()
    {
        // Check if the player moves and touches the ground (to avoid playing sounds in the air)
        isWalking = fpc.playerCanMove && fpc.isGrounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);

        if (isWalking)
        {
            timeSinceLastStep += Time.deltaTime;

            // If the player is running, speed up the steps
            float currentFootstepDelay = Input.GetKey(KeyCode.LeftShift) ? footstepDelay / runMultiplier : footstepDelay;

            // Check if enough time has elapsed to play the next step sound
            if (timeSinceLastStep >= currentFootstepDelay)
            {
                PlayFootstepSound();
                timeSinceLastStep = 0f;  // Resetting the time to the next step
            }
        }
        else
        {
            // If the player doesn't go, reset the timer
            timeSinceLastStep = 0f;
        }
    }

    private void PlayFootstepSound()
    {
        // Play the sound of a step
        footstepAudioSource.PlayOneShot(footstepClip);
    }
}
