using TMPro;
using UnityEngine;

public class GlobalAmmo : MonoBehaviour
{
    public static int CurrentAmmo;
    public GameObject AmmoDisplay;
    private int InternalAmmo;

    void Update()
    {
        InternalAmmo = CurrentAmmo;
        AmmoDisplay.GetComponent<TextMeshProUGUI>().text = InternalAmmo.ToString();
    }
}