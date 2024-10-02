using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public GameObject endGamePanel;  // UI panel that appears at the end of the game
    public TextMeshProUGUI timerText;  // UI text to display the timer
    private bool gameEnded = false;  // Flag to check if the game is over
    private float elapsedTime = 0f;  // Time since the start of the game
    public FirstPersonController fpc;  // Link to the character control script


    private void Start()
    {
        // Zeroing the timer at the beginning of the game
        elapsedTime = 0f;
        gameEnded = false;
    }

    private void Update()
    {
        if (!gameEnded)
        {
            // Increase the time by the elapsed time since the last frame
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check that the trigger is activated only when colliding with a player
        if (other.CompareTag("Player") && !gameEnded)
        {
            EndGame();
        }
    }

    // Method for completing the game
    private void EndGame()
    {
        endGamePanel.SetActive(true);  // Show end of game panel
        Time.timeScale = 0f;  // Stopping time in the game
        fpc.cameraCanMove = false;  // Disabling camera movement
        Cursor.visible = true;  // Showing the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        gameEnded = true;  // Set the end-of-game flag
    }

    // Method for updating the timer on the screen
    private void UpdateTimerUI()
    {
        // Convert time to MM:SS format and display it
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
