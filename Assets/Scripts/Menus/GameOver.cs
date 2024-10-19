using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private int LoadInt; // Stores the saved scene index

    void Start()
    {
        // Retrieve the saved scene index from PlayerPrefs
        LoadInt = PlayerPrefs.GetInt("AutoSave", 1); // Default to scene 1 if not found
    }

    public void LoadGameButton()
    {
        StartCoroutine(LoadGameCoroutine());
    }

    public void LoadMainMenuButton()
    {
        StartCoroutine(LoadMainMenuCoroutine());
    }

    IEnumerator LoadGameCoroutine()
    {
        // Activate fade-out and loading screen effects
        yield return new WaitForSeconds(0);

        // Load the saved game scene
        SceneManager.LoadScene(LoadInt);
    }

    IEnumerator LoadMainMenuCoroutine()
    {
        // Activate fade-out and loading screen effects
        yield return new WaitForSeconds(0);

        // Load the main menu scene (scene index 0)
        SceneManager.LoadScene(0);
    }
}
