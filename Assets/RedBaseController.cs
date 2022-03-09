using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBaseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FlagLight" && other.gameObject.transform.parent.parent.parent.parent.tag != "Player")
        {
            other.gameObject.GetComponentInParent<FlagController>().FlagScored();
        }
    }
}
