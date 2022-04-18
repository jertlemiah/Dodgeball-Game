using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // [SerializeField] float rotateSpeed = 1;
    [SerializeField] Vector3 rotationVector = new Vector3(0,25,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime*rotationVector.x, Time.deltaTime*rotationVector.y, Time.deltaTime*rotationVector.z);
    }
}
