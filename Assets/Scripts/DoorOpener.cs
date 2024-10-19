using TMPro;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Door;
    public GameObject InteractionCrossHair;

    private bool isOpened = false;

    void Update()
    {
        // Check if the player is looking at this door opener object
        if (!isOpened && PlayerRaycast.Target == gameObject)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Open Door";
            InteractionCrossHair.SetActive(true);

            if (Input.GetButtonDown("Action"))
            {
                // Open the door
                isOpened = true;
                GetComponent<BoxCollider>().enabled = false;

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                InteractionCrossHair.SetActive(false);

                Animation animation = Door.GetComponent<Animation>();
                animation.Play(animation.clip.name);
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