using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public int totalKeysRequired = 5;  // Number of keys required for animation
    public TextMeshProUGUI keyCountText;  // UI element to display the number of keys
    public Animator doorAnimator;  // Animator of a door or other object
    public string animationTriggerName = "OpenDoor";  

    private int keysCollected = 0;  // Number of keys collected

    // A method for handling key collisions
    private void OnTriggerEnter(Collider other)
    {
        // Check that the object is a key by the “Key” tag
        if (other.CompareTag("Key"))
        {
            // Increase the number of keys
            keysCollected++;

            // Updating the UI with the number of keys
            UpdateKeyCountText();

            // Removing the key from the scene
            Destroy(other.gameObject);

            // If enough keys have been collected, start the animation
            if (keysCollected >= totalKeysRequired)
            {
                PlayAnimation();
            }
        }
    }

    // Method for updating the text on the screen
    private void UpdateKeyCountText()
    {
        keyCountText.text = "Keys: " + keysCollected + "/" + totalKeysRequired;
    }

    // Method to start the animation
    private void PlayAnimation()
    {
        if (doorAnimator != null && !string.IsNullOrEmpty(animationTriggerName))
        {
            doorAnimator.SetTrigger(animationTriggerName);
        }
    }
}
