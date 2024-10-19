using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpeningA : MonoBehaviour
{
    public GameObject Player;
    public GameObject FadeInScreen;
    public GameObject TextBox;
    
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<PlayerController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeInScreen.SetActive(false);
        TextBox.GetComponent<TextMeshProUGUI>().text = "What happened?";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        TextBox.GetComponent<TextMeshProUGUI>().text = "Where am I?";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        Player.GetComponent<PlayerController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
