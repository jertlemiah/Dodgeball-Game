using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    public bool useStaticBillboard;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard) {
            transform.LookAt(Camera.main.transform);
        } else {
            transform.rotation = Camera.main.transform.rotation;
        }
        
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
