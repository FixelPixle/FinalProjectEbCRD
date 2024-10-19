using TMPro;
using UnityEngine;

public class PistolPickUp : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject IndicationArrow;
    public GameObject InteractionCrossHair;
    public GameObject BargeDoorTrigger;

    private bool isPickedUp = false;

    void Update()
    {
        // Check if the player is looking at this PistolPickUp object
        if (!isPickedUp && PlayerRaycast.Target == gameObject)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Pick Up Pistol";
            InteractionCrossHair.SetActive(true);

            if (Input.GetButtonDown("Action"))
            {
                // Perform the pickup action
                isPickedUp = true;
                GetComponent<BoxCollider>().enabled = false;

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                InteractionCrossHair.SetActive(false);

                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                IndicationArrow.SetActive(false);
                BargeDoorTrigger.SetActive(true);
            }
        }
        else if (PlayerRaycast.Target != gameObject && PlayerRaycast.PreviousTarget == gameObject)
        {
            // Hide UI elements when not looking at the pistol
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            InteractionCrossHair.SetActive(false);
        }
        
    }
}