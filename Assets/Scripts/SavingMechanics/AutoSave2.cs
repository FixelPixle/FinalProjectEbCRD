using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

