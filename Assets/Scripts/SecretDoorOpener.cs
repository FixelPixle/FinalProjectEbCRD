using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorOpener : MonoBehaviour
{
    public GameObject secretDoor;  
    public GameObject secretDoor2; 

    private Animation SecretDoorAnimation; 

    
    void Start()
    {
        
        SecretDoorAnimation = secretDoor.GetComponent<Animation>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            SecretDoorAnimation.Play();

            
            secretDoor2.SetActive(false);
        }
    }
}