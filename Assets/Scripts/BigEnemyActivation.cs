using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyActivation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers this
        {
            Debug.Log("Player entered the trigger zone");
            BigEnemyAI.isFollowing = true; // Start following
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers this
        {
            Debug.Log("Player exited the trigger zone");
            BigEnemyAI.isFollowing = false; // Stop following
        }
    }
}