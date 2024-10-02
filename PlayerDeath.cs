using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathScreenUI;  
    public Button respawnButton;  // Respawn button
    public FirstPersonController fpc;  // Link to the character control script
    public Transform[] checkpoints;  // Array of checkpoints for respawning
    private Transform currentCheckpoint;  // Current checkpoint to which the player is respawning
    public AudioSource audioSource;
    public AudioClip deathSound; // The sound that plays when you die

    private bool isDead = false;  // Variable to track the state of death

    private void Start()
    {
        // Initially hide the screen of death and set the initial checkpoint
        deathScreenUI.SetActive(false);
        currentCheckpoint = checkpoints[0];  // Initial checkpoint
        respawnButton.onClick.AddListener(Respawn);  // Add an action for the respawn button
    }

    // A method for killing a player
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;  // Set the status of death
            Time.timeScale = 0f;  // Stopping time
            deathScreenUI.SetActive(true);  // Showing the screen of death
            Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
            Cursor.visible = true;  // Making the cursor visible
            fpc.cameraCanMove = false;  // Disabling camera movement
            audioSource.PlayOneShot(deathSound);

        }
    }

    // Method for respawning a player
    public void Respawn()
    {
        isDead = false;  // Resetting the death status
        deathScreenUI.SetActive(false);  // Hiding the screen of death
        Time.timeScale = 1f;  // Bringing back the time
        Cursor.lockState = CursorLockMode.Locked;  // Hide and lock the cursor
        Cursor.visible = false;
        fpc.cameraCanMove = true;  // Disabling camera movement
        // Перемещаем игрока к последнему чекпоинту
        transform.position = currentCheckpoint.position;
        transform.rotation = currentCheckpoint.rotation;
    }

    // Method for setting up a new checkpoint
    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;  // Installing a new checkpoint
    }

    // Trigger for interaction with checkpoints and traps
    private void OnTriggerEnter(Collider other)
    {
        // Traps with the tag "trap" kill the player
        if (other.CompareTag("trap"))
        {
            Die();
        }

        // If the player crosses a checkpoint, update the current checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            SetCheckpoint(other.transform);  // Installing a new checkpoint
        }
    }

}
