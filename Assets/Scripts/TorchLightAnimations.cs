using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightAnimations : MonoBehaviour
{

    public int TorchLightState;
    public GameObject torchLight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TorchLightState == 0)
        {
            StartCoroutine(AnimateLight());
        }

        IEnumerator AnimateLight()
        {
            TorchLightState = Random.Range(1, 4);
            if (TorchLightState == 1)
            {
                torchLight.GetComponent<Animation>().Play("TorchLightAnimation1");
            }
            else if (TorchLightState == 2)
            {
                torchLight.GetComponent<Animation>().Play("TorchLightAnimation2");
            }
            else if (TorchLightState == 3)
            {
                torchLight.GetComponent<Animation>().Play("TorchLightAnimation3");
            }
            yield return new WaitForSeconds(0.99f);
            TorchLightState = 0;
        }


}
}