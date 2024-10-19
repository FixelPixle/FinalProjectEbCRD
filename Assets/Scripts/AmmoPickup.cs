using TMPro;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject InteractionCrossHair;
    public GameObject AmmoBox; // Reference to the ammo box GameObject

    public int AmmoAmount = 10; // Amount of ammo to add on pickup

    private bool isPickedUp = false;

    void Update()
    {
        if (!isPickedUp && PlayerRaycast.Target == gameObject)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Pick Up Ammo";
            InteractionCrossHair.SetActive(true);

            if (Input.GetButtonDown("Action"))
            {
                // Increase player's ammo
                GlobalAmmo.CurrentAmmo += AmmoAmount;

                // Disable the ammo box
                AmmoBox.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;

                // Disable interaction UI
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                InteractionCrossHair.SetActive(false);

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
}