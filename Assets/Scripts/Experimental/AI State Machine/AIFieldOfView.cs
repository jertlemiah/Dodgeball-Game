using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFieldOfView : MonoBehaviour
{
    public bool disableVisuals;
    [Range(0,100)] public float outerViewRadius = 20f;
    [Range(0,100)] public float middleViewRadius = 10f;
    [Range(0,100)] public float innerViewRadius = 5f;
    [Range(0,360)] public float outerViewAngle = 80f;
    [Range(0,360)] public float middleViewAngle = 150f;
    [Range(0,360)] public float innerViewAngle = 360f;
    public LayerMask obstacleMask;
    public LayerMask playerMask;
    public LayerMask ballMask;
    public List<Transform> visiblePlayers = new List<Transform>();
    public List<Transform> visibleBalls = new List<Transform>();
    public float meshResolution = 0.5f;
    public MeshFilter outerViewMeshFilter;
    public MeshFilter middleViewMeshFilter;
    public MeshFilter innerViewMeshFilter;
    Mesh outerViewMesh;
    Mesh middleViewMesh;
    Mesh innerViewMesh;
    public int edgeResolveIterations = 10;
    public float edgeDistThreshold = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        outerViewMesh = new Mesh();
        outerViewMesh.name = "Outer View Mesh";
        outerViewMeshFilter.mesh = outerViewMesh;

        middleViewMesh = new Mesh();
        middleViewMesh.name = "Middle View Mesh";
        middleViewMeshFilter.mesh = middleViewMesh;

        innerViewMesh = new Mesh();
        innerViewMesh.name = "Inner View Mesh";
        innerViewMeshFilter.mesh = innerViewMesh;
        StartCoroutine("FindTargetsWithDelay",0.2f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!disableVisuals){
            outerViewMeshFilter.gameObject.SetActive(true);
            middleViewMeshFilter.gameObject.SetActive(true);
            innerViewMeshFilter.gameObject.SetActive(true);
            DrawFieldOfView(outerViewRadius, outerViewAngle, outerViewMesh) ;
            DrawFieldOfView(middleViewRadius, middleViewAngle, middleViewMesh) ;
            DrawFieldOfView(innerViewRadius, innerViewAngle, innerViewMesh) ;
        } else {
            outerViewMeshFilter.gameObject.SetActive(false);
            middleViewMeshFilter.gameObject.SetActive(false);
            innerViewMeshFilter.gameObject.SetActive(false);
        }
        
    }

    void DrawFieldOfView(float fowRadius, float fowAngle, Mesh mesh) 
    {
        int stepCount = Mathf.RoundToInt(fowAngle * meshResolution);
        float stepAngleSize = fowAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();

        for (int i = 0; i <= stepCount; i++){
            float angle = transform.eulerAngles.y - fowAngle/2 + stepAngleSize*i;
            // Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle,true) * viewRadius, Color.yellow);
            ViewCastInfo newViewCast = ViewCast(angle,fowRadius);

            if(i > 0) {
                bool edgeDistThresholdExceeded = Mathf.Abs(oldViewCast.dist - newViewCast.dist) > edgeDistThreshold;
                if (oldViewCast.hit != newViewCast.hit || oldViewCast.hit && newViewCast.hit && edgeDistThresholdExceeded) {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast, fowRadius);
                    if(edge.pointA != Vector3.zero) {
                        viewPoints.Add (edge.pointA);
                    } 
                    if(edge.pointB != Vector3.zero) {
                        viewPoints.Add (edge.pointB);
                    } 
                }
            }


            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount-2) * 3];

        vertices[0] = Vector3.zero;
        for (int i=0; i < vertexCount - 1; i++) {
            vertices [i+1] = transform.InverseTransformPoint(viewPoints[i]);

            if(i < vertexCount-2){
                triangles[i*3] = 0;
                triangles[i*3 + 1] = i + 1;
                triangles[i*3 + 2] = i + 2;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast, float fowRadius) 
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero; 

        for(int i=0; i < edgeResolveIterations; i++) {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle,fowRadius);

            bool edgeDistThresholdExceeded = Mathf.Abs(minViewCast.dist - newViewCast.dist) > edgeDistThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDistThresholdExceeded) {
                minAngle = angle;
                minPoint = newViewCast.point;
            } else {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }  

        return new EdgeInfo(minPoint, maxPoint);
    }

    ViewCastInfo ViewCast(float globalAngle, float viewRadius) {
        Vector3 dir = DirFromAngle (globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask)) {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        } else {
            return new ViewCastInfo(false, transform.position + dir*viewRadius, viewRadius, globalAngle);
        }
    }

    public struct ViewCastInfo 
    {
        public bool hit;
        public Vector3 point;
        public float dist;
        public float angle;
        public ViewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle){
            hit = _hit;
            point = _point;
            dist = _dist;
            angle = _angle;
        }
    }

    IEnumerator FindTargetsWithDelay(float delay){
        while(true) {
            yield return new WaitForSeconds(delay);
            visiblePlayers.Clear();
            visibleBalls.Clear();
            FindVisibleTargets(outerViewRadius,outerViewAngle);
            FindVisibleTargets(middleViewRadius,middleViewAngle);
            FindVisibleTargets(innerViewRadius,innerViewAngle);
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void FindVisibleTargets(float viewRadius, float viewAngle){
        
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask | ballMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 targetCenter = target.position;
            if(IsInLayerMask(target.gameObject, playerMask)){
                targetCenter = targetCenter + target.GetComponent<CharacterController>().center;
            }
            

            Vector3 dirToTarget = (targetCenter - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                float distToTarget = Vector3.Distance(transform.position, targetCenter);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask)) {
                    if(IsInLayerMask(target.gameObject, playerMask) && !visiblePlayers.Contains(target)) {
                        visiblePlayers.Add(target);
                    } else if(IsInLayerMask(target.gameObject, ballMask) && !visibleBalls.Contains(target.GetComponentInParent<DodgeballController>().transform)) {
                        visibleBalls.Add(target.parent);
                    } 
                    // else {
                    //     Debug.Log("this object wasn't classified for some reason: "+target.name);
                    // }
                }
            }
        }
    }

    public bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }

    public struct EdgeInfo {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB){
            pointA = _pointA;
            pointB = _pointB;
        }
    }
}
