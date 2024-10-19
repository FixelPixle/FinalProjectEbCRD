using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject InteractionCrossHair;
    public GameObject FadeOut;

    private bool isOpened = false;

    void Update()
    {
        // Check if the player is looking at this door object
        if (!isOpened && PlayerRaycast.Target == gameObject)
        {
            // Check if the key has been picked up
            if (KeyPickupDownstairs.isPickedUp)
            {
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
                ActionText.GetComponent<TextMeshProUGUI>().text = "Open Door";
                InteractionCrossHair.SetActive(true);

                if (Input.GetButtonDown("Action"))
                {
                    // Open the door and initiate exit sequence
                    isOpened = true;
                    GetComponent<BoxCollider>().enabled = false;

                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    InteractionCrossHair.SetActive(false);
                    FadeOut.SetActive(true);
                    StartCoroutine(FadeToExit());
                }
            }
            else
            {
                // Show "Key Required" message without action prompt
                ActionDisplay.SetActive(false);
                ActionText.SetActive(true);
                ActionText.GetComponent<TextMeshProUGUI>().text = "Key Required";
                InteractionCrossHair.SetActive(true);
            }
        }
        else if (PlayerRaycast.Target != gameObject && PlayerRaycast.PreviousTarget == gameObject)
        {
            // Hide UI elements when not looking at the door
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            InteractionCrossHair.SetActive(false);
        }
    }

    IEnumerator FadeToExit()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2); // Adjust the scene index as needed
    }
}
