using TMPro;
using UnityEngine;
using System.Collections;

public class PuzzlePiecePickup : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject InteractionCrossHair;
    public GameObject PuzzlePieceObject; 
    public GameObject HalfFade;  
    public GameObject PuzzleImage;  
    public GameObject PuzzleText;  
    public GameObject particleEffect; 

    public string puzzlePieceName; // Unique identifier for this puzzle piece (e.g., "PuzzlePiece1", "PuzzlePiece2")

    private bool isPickedUp = false; 
    private MeshRenderer meshRenderer; // For hiding the puzzle piece visually
    private Collider puzzleCollider; // To disable the collider without deactivating the object

    void Start()
    {
        // Cache the MeshRenderer and Collider components
        meshRenderer = PuzzlePieceObject.GetComponent<MeshRenderer>();
        puzzleCollider = PuzzlePieceObject.GetComponent<Collider>();
    }

    void Update()
    {
        // Check if the player is looking at the puzzle piece and has not picked it up yet
        if (!isPickedUp && PlayerRaycast.Target == gameObject)
        {
            // Show interaction UI for the puzzle piece
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Pick Up Puzzle Piece";
            InteractionCrossHair.SetActive(true);

            
            if (Input.GetButtonDown("Action"))
            {
                GlobalInventory.Instance.AddItem(puzzlePieceName);

                // Hide the puzzle piece visually and disable its collider (but don't deactivate it)
                meshRenderer.enabled = false;
                puzzleCollider.enabled = false;

                // Disable the particle effect
                if (particleEffect != null)
                {
                    particleEffect.SetActive(false);
                }

                // Disable interaction UI
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                InteractionCrossHair.SetActive(false);

                // Trigger the UI elements to show and start the 4-second coroutine to hide them
                ShowPuzzleUI();
                
                isPickedUp = true;
            }
        }
        else if (PlayerRaycast.Target != gameObject && PlayerRaycast.PreviousTarget == gameObject)
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            InteractionCrossHair.SetActive(false);
        }
    }

    
    private void ShowPuzzleUI()
    {
        HalfFade.SetActive(true);
        PuzzleImage.SetActive(true);
        PuzzleText.SetActive(true);

        
        StartCoroutine(HidePuzzleUIAfterDelay());
    }
    
    private IEnumerator HidePuzzleUIAfterDelay()
    {
        yield return new WaitForSeconds(4f);

        
        HalfFade.SetActive(false);
        PuzzleImage.SetActive(false);
        PuzzleText.SetActive(false);
    }
}
