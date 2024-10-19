using UnityEngine;
using TMPro;
using System.Collections;

public class PlacePuzzle : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject InteractionCrossHair;
    public GameObject fullImageObject; 
    public GameObject wallWithAnimation; 
    public string puzzlePieceLeftName = "PuzzlePieceLeft"; 
    public string puzzlePieceRightName = "PuzzlePieceRight"; 
    private Animation PuzzleDoorAnimationReal; 
    private bool puzzleCompleted = false;

    void Start()
    {
        // Get the Animation component from the wall object
        PuzzleDoorAnimationReal = wallWithAnimation.GetComponent<Animation>();
    }

    void Update()
    {
        // Check if the player is looking at the puzzle placement area
        if (!puzzleCompleted && PlayerRaycast.Target == gameObject)
        {
            InteractionCrossHair.SetActive(true);

            // Check if the player has both puzzle pieces
            if (GlobalInventory.Instance.HasItem(puzzlePieceLeftName) && GlobalInventory.Instance.HasItem(puzzlePieceRightName))
            {
                // Show "Place Puzzle" interaction
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
                ActionText.GetComponent<TextMeshProUGUI>().text = "Place Puzzle";

                if (Input.GetButtonDown("Action"))
                {
                    // Activate the full puzzle image
                    fullImageObject.SetActive(true);
                    puzzleCompleted = true;

                    // Hide UI after placing the puzzle
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    InteractionCrossHair.SetActive(false);

                    // Start the wall animation after a 1-second delay
                    StartCoroutine(PlayWallAnimation());
                }
            }
            else
            {
                // Show "Puzzle Pieces Required" if the player doesn't have both pieces
                ActionDisplay.SetActive(false);
                ActionText.SetActive(true);
                ActionText.GetComponent<TextMeshProUGUI>().text = "Puzzle Pieces Required";
            }
        }
        else if (PlayerRaycast.Target != gameObject && PlayerRaycast.PreviousTarget == gameObject)
        {
            // Hide UI elements when not looking at the puzzle placement
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            InteractionCrossHair.SetActive(false);
        }
    }

    // Coroutine to play the wall animation after 1 second
    IEnumerator PlayWallAnimation()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second
        PuzzleDoorAnimationReal.Play(); // Play the wall's animation
    }
}
