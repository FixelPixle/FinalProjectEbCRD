using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public static GameObject Target;
    public static GameObject PreviousTarget;
    public static float DistanceFromTarget;

    public float raycastRange = 5f; // Maximum interaction distance
    public LayerMask interactionLayers; // Layers to include in the raycast

    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        RaycastHit hit;

        // Perform a raycast from the camera's position, forward direction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, raycastRange, interactionLayers))
        {
            DistanceFromTarget = hit.distance;
            if (Target != null)
            {
                PreviousTarget = Target;
            }
            else
            {
                PreviousTarget = null;
            }
            
            Target = hit.collider.gameObject;
        }
        else
        {
            DistanceFromTarget = 0f;
            Target = null;
        }
    }
}