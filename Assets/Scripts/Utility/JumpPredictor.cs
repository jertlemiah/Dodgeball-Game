using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class JumpPredictor : MonoBehaviour
{
    public bool disableVisuals = false;
    [SerializeField] UnitController unitController;
    [SerializeField] LineRenderer lineRenderer  => GetComponent<LineRenderer>();
    [SerializeField] GameObject hitSpot;
    [SerializeField] GameObject landingSpot;
    public float speedVert = 5;
    public float speedHorz = 5;
    public float gravity = -9.81f;
    public LayerMask collidableLayers;
    [Range (0.0001f,1f)] public float timeBetweenPoints = 0.1f;

    public int numPoints = 50;
    [Range (0.0001f,1f)] public float progressSteps = 0.1f;
    public float predictedRange = 1f, predictedHeight = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if(!unitController){
            Debug.LogError(gameObject.name+" does not have unitController assigned. Must have a unitController to work properly.");
        }
        // if(!flightPathSpline)
        //     flightPathSpline = GetComponent<FlightPath>();
        // if(!lineRenderer)
        //     lineRenderer = GetComponent<LineRenderer>();
        initialPos = this.transform.localPosition;
        gravity = unitController.Gravity;
    }
    public bool freezePos = false;
    public Vector3 initialPos;
    // Update is called once per frame
    void Update()
    {
        if(!unitController){
            return;
        }

        // StayOnGround();
        if(unitController.Grounded){
            frozenPosition = transform.position;
            freezePos = false;
        } else {
            freezePos = true;
            
        }

        if(freezePos){
            FreezePosition();
        } else {
            transform.localPosition = initialPos;
        }
        DrawProjection();
        if(disableVisuals){
            lineRenderer.enabled = false;
            if(hitSpot){
                hitSpot.SetActive(false);
            }
            if(landingSpot){
                landingSpot.SetActive(false);
            }
        } else {
            lineRenderer.enabled = true;
            if(hitSpot){
                hitSpot.SetActive(true);
            }
            if(landingSpot){
                landingSpot.SetActive(true);
            }
        }
        // // _verticalVelocity = Mathf.Sqrt(unitController.JumpHeight * -2f * unitController.Gravity);
    }
    public Vector3 frozenPosition;

    void FreezePosition()
    {
        transform.position = frozenPosition;
    }

    void StayOnGround()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, collidableLayers))
        {
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // Debug.Log("Did Hit");
            transform.position = new Vector3(transform.position.x,transform.position.y - hit.distance + 0.2f, transform.position.z);
        }
    }

    void DrawProjection()
    {
        speedVert = Mathf.Sqrt(unitController.JumpHeight * -2f * unitController.Gravity);
        Vector3 verticalVelocity = unitController.transform.up * speedVert;
        speedHorz = unitController.MoveSpeed;
        Vector3 horizontalVelocity = unitController.transform.forward * speedHorz;
        
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        // Vector3 startingPosition = unitController.transform.position;
        Vector3 startingPosition = this.transform.position;
        // Vector3 startingVelocity = cannonController.ShotPoint.up * cannonController.BlastPower;
        


        Vector3 startingVelocity = verticalVelocity + horizontalVelocity;
        Vector3 newPoint = startingPosition;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {   
            newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + (gravity)/2f * t * t;
            points.Add(newPoint);

            if(t!=0 && Physics.OverlapSphere(newPoint, 0.1f, collidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;  
                break;
            }
        }
        if(hitSpot){
            hitSpot.transform.position = newPoint;
            if(landingSpot){
                // Place the landing spot at the closet point on the navmesh that is below the hitSpot
                RaycastHit hit;
                NavMeshHit navHit;
                if(Physics.Raycast(newPoint, Vector3.down, out hit, Mathf.Infinity, collidableLayers)){
                    NavMesh.SamplePosition(hit.point,out navHit,4f, NavMesh.AllAreas);
                } else {
                    NavMesh.SamplePosition(newPoint,out navHit,4f, NavMesh.AllAreas);
                }

                landingSpot.transform.position = navHit.position;
            }
        }
        
        // startingVelocity.
        float angle = Vector3.Angle(transform.forward,startingVelocity);
        // predictedRange = 2 * Mathf.Pow(playerController.throwPower,2) * Mathf.Cos(angle * (Mathf.PI / 180f) )* Mathf.Sin(angle * (Mathf.PI / 180f)) / (liftForce * 9.81f);
        float theta = angle* (Mathf.PI / 180f) ;
        float v = unitController.MoveSpeed;
        float h = transform.position.y;
        predictedRange = (float)(((Mathf.Pow(v,2)*Mathf.Cos(theta) * Mathf.Sin(theta))/(gravity)) + 
                        ((v*Mathf.Cos(theta)*Mathf.Sqrt(Mathf.Pow(v,2)*Mathf.Pow(Mathf.Sin(theta),2))+2*h*(gravity))/(gravity)));
        
        predictedHeight = (float)(Mathf.Pow(v*Mathf.Sin(theta),2) / (2f*(gravity)) + h);

        lineRenderer.SetPositions(points.ToArray());
        // lineRenderer.alignment = LineAlignment.TransformZ;
    }
}
