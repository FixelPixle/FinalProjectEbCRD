using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class CreditScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to load the main menu scene after 15 seconds
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    // Coroutine to wait for 15 seconds before loading the main menu
    IEnumerator LoadMainMenuAfterDelay()
    {
        // Wait for 15 seconds
        yield return new WaitForSeconds(15f);

        // Unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the MainMenuScene (replace with your actual scene name)
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}