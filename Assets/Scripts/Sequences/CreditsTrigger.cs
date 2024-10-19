using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTrigger : MonoBehaviour
{
    
    public GameObject fadeOutUIElement; // Assign your fade-out UI element here
    public string playerTag = "Player"; // The tag assigned to your player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Disable the collider to prevent multiple triggers
            GetComponent<Collider>().enabled = false;

            // Activate the fade-out UI element
            fadeOutUIElement.SetActive(true);

            // Start the coroutine to wait and then load the credits scene
            StartCoroutine(WaitAndLoadCredits());
        }
    }

    private IEnumerator WaitAndLoadCredits()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Load the credits scene
        SceneManager.LoadScene(5);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
