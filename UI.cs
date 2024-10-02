using UnityEngine;
using UnityEngine.SceneManagement;



public class UI : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Pause menu bar
    public GameObject hello;  // Welcome Panel
    private bool isPaused = false;  // Flag to indicate whether the game is paused or not
    public FirstPersonController fpc;  // Link to the character control script


    private void Start()
    {


        Hello();
    }

    void Update()
    {
        // Check if the ESC key or the button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Hello()
    {
        hello.SetActive(true);  // Showing the welcome panel
        Time.timeScale = 0f;  // Stop time in the game
        isPaused = true;  // Set the pause flag to true
        fpc.cameraCanMove = false;  // Disabling camera movement
        Cursor.visible = true;  // Showing the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
    }

    // Method for resuming play
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hiding the pause menu
        hello.SetActive(false);  // Hiding the welcome panel

        Time.timeScale = 1f;  // Return the normal time rate
        isPaused = false;  // Set the pause flag to false
        fpc.cameraCanMove = true;  // Activating camera movement
        Cursor.visible = false;  // Hiding the cursor
        Cursor.lockState = CursorLockMode.Locked;  // Locking the cursor
    }

    // Method for pausing the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);  // Showing the pause menu
        Time.timeScale = 0f;  
        isPaused = true;  
        fpc.cameraCanMove = false;  
        Cursor.visible = true;  
        Cursor.lockState = CursorLockMode.None;  
    }
    // Method for quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Method for restarting the game
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Set the normal time rate
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restart the current scene
    }
}
