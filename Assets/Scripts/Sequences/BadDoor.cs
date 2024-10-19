using UnityEngine;
using System.Collections;

public class BadDoor : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Door; // Reference to the door GameObject

    private bool enemiesActivated = false;

    void Start()
    {
        // Initially deactivate enemies
        Enemy1.SetActive(false);
        Enemy2.SetActive(false);

        // Start the coroutine to monitor the door animation
        StartCoroutine(MonitorDoorOpening());
    }

    IEnumerator MonitorDoorOpening()
    {
        Animation doorAnimation = Door.GetComponent<Animation>();
        if (doorAnimation == null)
        {
            Debug.LogError("EnemyActivator: No Animation component found on the Door GameObject.");
            yield break;
        }

        string animationName = doorAnimation.clip.name;

        // Wait until the door's animation starts playing
        while (!doorAnimation.isPlaying)
        {
            yield return null;
        }

        // Wait until the door's animation finishes playing
        while (doorAnimation.isPlaying)
        {
            yield return null;
        }

        // Activate enemies after the door has opened
        if (!enemiesActivated)
        {
            enemiesActivated = true;
            Enemy1.SetActive(true);
            Enemy2.SetActive(true);
        }
    }
}