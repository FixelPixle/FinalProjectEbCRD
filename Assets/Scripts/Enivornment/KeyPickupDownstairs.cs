using TMPro;
using UnityEngine;

public class KeyPickupDownstairs : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject InteractionCrossHair;
    public GameObject KeyObject; // Reference to the key GameObject

    // Static variable to track if the key has been picked up
    public static bool isPickedUp = false;

    void Update()
    {
        // Check if the player is looking at the key and has not picked it up yet
        if (!isPickedUp && PlayerRaycast.Target == gameObject)
        {
            // Show interaction UI for the key
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Pick Up Key";
            InteractionCrossHair.SetActive(true);

            // Check if the player presses the action button
            if (Input.GetButtonDown("Action"))
            {
                // Mark the key as picked up
                isPickedUp = true;

                // Disable the key object (it disappears once picked up)
                KeyObject.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;

                // Disable interaction UI
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                InteractionCrossHair.SetActive(false);
            }
        }
        else if (PlayerRaycast.Target != gameObject && PlayerRaycast.PreviousTarget == gameObject)
        {
            // Hide interaction UI if player is not looking at the key
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            InteractionCrossHair.SetActive(false);
        }
    }
}