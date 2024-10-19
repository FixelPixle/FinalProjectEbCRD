using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBreak : MonoBehaviour
{

    public GameObject fakeVase;
    public GameObject brokenVase;
    public GameObject sphereObject;
    public GameObject Key;
    
    
    
    public void BreakVase()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        brokenVase.SetActive(true);
        gameObject.SetActive(false);
        sphereObject.SetActive(true);
        Key.SetActive(true);
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
