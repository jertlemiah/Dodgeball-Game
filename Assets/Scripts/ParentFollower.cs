using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFollower : MonoBehaviour
{
    [SerializeField] Vector3 vel;
    [SerializeField] float angle;
    [SerializeField] Vector3 initialRotation;
    [SerializeField] public GameObject childToFollow;
    [SerializeField] float lerpTime = 1f;
    public bool rotateWithVel = true;
    public bool lockToYRot = true;
    // Start is called before the first frame update
    void Start()
    {
        // transform.rotation = Quaternion.identity;
        transform.eulerAngles = initialRotation;
        if(!childToFollow)
            childToFollow = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.parent.position = transform.position;
        // Vector3 childPos = transform.GetChild(0).transform.position;
        Vector3 childPos = childToFollow.transform.position;
        transform.position = childPos;
        // transform.parent.position = transform.position - transform.localpostiion;
        childToFollow.transform.position = transform.position;

        if(rotateWithVel)
        {
            // vel = flightPath.GetVelocity(discController.progress);
            vel = GetComponentInChildren<Rigidbody>().velocity;
             Vector3 newDir;
            if(vel.magnitude > 0.01)
            {
                newDir = Vector3.Normalize(new Vector3(vel.x,0,vel.z));
            }
            else
            {
                newDir = transform.forward;
            }
            
            // transform.forward = Vector3.Lerp(transform.forward,newDir,lerpTime);
            // transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.forward),Quaternion.Euler(newDir),lerpTime);
            transform.forward = Vector3.Lerp(transform.forward, newDir, Time.deltaTime*lerpTime);

            // angle = Mathf.Atan(vel.x/vel.z)*180f/Mathf.PI;
            // // transform.rotation = new Quaternion(vel);
            // Vector3 eulers = this.transform.rotation.eulerAngles;
            // // this.transform.rotation = Quaternion.Euler(new Vector3(vel.x,eulers.y,eulers.z));
            // Vector3 newEuler = initialRotation + new Vector3(0,-angle,0);
            // // Vector3 newEuler = initialRotation + new Vector3(-angle,eulers.y,eulers.z);
            // transform.eulerAngles = newEuler;
            // childToFollow.transform.eulerAngles = newEuler+ new Vector3(-90,0,0);;
            // transform.GetChild(0).transform.eulerAngles = new Vector3(-angle,0,0);
            // Quaternion quat = Quaternion.Euler(-angle,0,0);
            // transform.rotation = Quaternion.Lerp(transform.rotation,quat,0.01f);
        }
        

    }
}
