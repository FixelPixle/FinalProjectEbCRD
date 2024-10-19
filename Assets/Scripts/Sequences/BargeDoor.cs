using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargeDoor : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        Door.GetComponent<Animation>().Play("BargeDoorAnimation");
        Enemy.SetActive(true);
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
