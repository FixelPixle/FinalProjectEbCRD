using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject fadeOutScreen;
    public GameObject loadingScreenText;
    
    public GameObject LoadButton;
    public int LoadInt;
    
    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }
    
    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    public void ExitGameButton()  // Functionality for exiting the game
    {
        Debug.Log("Game is exiting...");
        Application.Quit();  // This will quit the game when running a built version
    }
    
    IEnumerator NewGameStart()
    {
        fadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        loadingScreenText.SetActive(true);
        SceneManager.LoadScene(4);
    }
    
    IEnumerator LoadGameStart()
    {
        fadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        loadingScreenText.SetActive(true);
        SceneManager.LoadScene(LoadInt);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LoadInt = PlayerPrefs.GetInt("AutoSave");
        if (LoadInt > 0)
        {
            LoadButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}