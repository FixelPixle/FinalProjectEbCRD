using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneSequencing : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject DateDisplay;
    public GameObject PlaceDisplay;
    public GameObject BlackScreen;
    public GameObject LoadText;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneSequence());
    }
    
    IEnumerator SceneSequence()
    {
        yield return new WaitForSeconds(2);
        PlaceDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        DateDisplay.SetActive(true);
        yield return new WaitForSeconds(4);
        PlaceDisplay.SetActive(false);
        DateDisplay.SetActive(false);
        yield return new WaitForSeconds(1);
        TextBox.GetComponent<TextMeshProUGUI>().text = "You have been assigned to investigate a series of weird events.";
        yield return new WaitForSeconds(4);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text = "They have been happening in the same location, and the police have been unable to find any leads.";
        yield return new WaitForSeconds(6);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text = "You are to investigate the area and report back to HQ with any findings.";
        yield return new WaitForSeconds(4);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<TextMeshProUGUI>().text = "Good luck, Agent.";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        LoadText.SetActive(true);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
