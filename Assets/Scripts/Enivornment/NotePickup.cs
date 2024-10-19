using TMPro;
using UnityEngine;
using System.Collections;

public class NotePickup : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject InteractionCrossHair;
    public GameObject NoteObject; // Reference to the note GameObject
    public GameObject HalfFade;  // UI element for fading
    public GameObject NoteText;  // UI text to show note content
    public GameObject particleEffect; // Reference to the particle effect GameObject

    public string noteContent; // The text content of the note

    private bool isPickedUp = false; // Track if the note has been picked up
    private MeshRenderer meshRenderer; // For hiding the note visually
    private Collider noteCollider; // To disable the collider without deactivating the object

    void Start()
    {
        // Cache the MeshRenderer and Collider components
        meshRenderer = NoteObject.GetComponent<MeshRenderer>();
        noteCollider = NoteObject.GetComponent<Collider>();
    }

    void Update()
    {
        // Check if the player is looking at the note and has not picked it up yet
        if (!isPickedUp && PlayerRaycast.Target == gameObject)
        {
            // Show interaction UI for the note
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Pick Up Note";
            InteractionCrossHair.SetActive(true);

            // Check if the player presses the action button
            if (Input.GetButtonDown("Action"))
            {
                // Log that the note has been picked up (you can add further inventory logic here)
                Debug.Log("Note picked up: " + noteContent);

                // Hide the note visually and disable its collider (but don't deactivate it)
                meshRenderer.enabled = false;
                noteCollider.enabled = false;

                // Disable the particle effect
                if (particleEffect != null)
                {
                    particleEffect.SetActive(false);
                }

                // Disable interaction UI
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                InteractionCrossHair.SetActive(false);

                // Trigger the UI elements to show the note content and start the 4-second coroutine to hide them
                ShowNoteUI();

                isPickedUp = true;
            }
        }
        else if (PlayerRaycast.Target != gameObject && PlayerRaycast.PreviousTarget == gameObject)
        {
            // Hide interaction UI if player is not looking at the note
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            InteractionCrossHair.SetActive(false);
        }
    }

    // Function to show UI and start hiding it after 4 seconds
    private void ShowNoteUI()
    {
        // Set the note content to display
        NoteText.GetComponent<TextMeshProUGUI>().text = noteContent;
        HalfFade.SetActive(true); // Enable any UI fade element you have
        NoteText.SetActive(true); // Show the note content text

        // Start coroutine to hide the note content after 4 seconds
        StartCoroutine(HideNoteUIAfterDelay());
    }

    // Coroutine to hide note-related UI after 4 seconds
    private IEnumerator HideNoteUIAfterDelay()
    {
        yield return new WaitForSeconds(25f);

        // Hide the note-related UI elements
        HalfFade.SetActive(false);
        NoteText.SetActive(false);
    }
}
