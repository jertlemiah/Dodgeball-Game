using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float m_Speed;
    private float movementX;
    private float movementY;  
    public Vector2 _look;
    public GameObject FollowTarget;
    private float vcam_offset;
    [SerializeField] float lookDamper = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 0.01f;
        vcam_offset = 4;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }


    // Update is called once per frame
    private void Update()
    {
        // rotate the camera
        transform.position = transform.position + new Vector3(movementX*m_Speed, 0, movementY*m_Speed);
        Vector3 targetAngle = Vector3.zero;
        if (movementX < 0.1f && movementX < 0.1f)
        {
            FollowTarget.transform.RotateAround(transform.position, Vector3.up, _look.x*lookDamper);
            // targetAngle = Vector3.Lerp(transform.eulerAngles,targetAngle)
        }

        // FollowTarget.transform.rotation = Quaternion.Euler(targetAngle);
        
    }
}
