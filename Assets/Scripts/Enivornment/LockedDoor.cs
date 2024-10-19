using TMPro;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Door; // Reference to this door's wing
    public GameObject InteractionCrossHair;

    // Unique identifier for the key required for this door
    public string requiredKeyName; // e.g., "Key1", "Key2"

    private bool isOpened = false;

    void Update()
    {
        // Check if the player is looking at this door wing
        if (!isOpened && PlayerRaycast.Target == gameObject)
        {
            InteractionCrossHair.SetActive(true);

            // Check if the player has the required key
            if (GlobalInventory.Instance.HasItem(requiredKeyName))
            {
                // Show "Open Door" if the player has the key
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
                ActionText.GetComponent<TextMeshProUGUI>().text = "Open Door";

                if (Input.GetButtonDown("Action"))
                {
                    // Open the door wing
                    isOpened = true;
                    GetComponent<BoxCollider>().enabled = false;

                    // Hide UI after the door is opened
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    InteractionCrossHair.SetActive(false);

                    // Play the door opening animation
                    Animation animation = Door.GetComponent<Animation>();
                    animation.Play(animation.clip.name);
                }
            }
            else
            {
                // Show "Key Required" if the player doesn't have the key
                ActionDisplay.SetActive(false);
                ActionText.SetActive(true);
                ActionText.GetComponent<TextMeshProUGUI>().text = "Key Required";
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
}
