using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HumanBone{
    public HumanBodyBones bone;
    [Range(0,1)]public float boneWeight = 1f;
}
[RequireComponent(typeof(Animator))]
public class AimIK : MonoBehaviour
{
    public bool enableIK = true;
    [Range(0,1)] [SerializeField] float IKweight = 1f;
    public Transform targetTransform;
    public bool overrideTarget;
    public Vector3 targetOverridePosition;
    public Transform headTransform;
    [SerializeField] int iterations = 10;
    public float angleLimit = 90f;
    public float distanceLimit = 1f;
    [SerializeField] public HumanBone[] humanBones;
    Transform[] boneTransforms;    
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        boneTransforms = new Transform[humanBones.Length];
        for (int i = 0; i < boneTransforms.Length; i++)
        {
            boneTransforms[i] = animator.GetBoneTransform(humanBones[i].bone);
        }
        targetOverridePosition = targetTransform.position;
    }

    Vector3 GetTargetPosition() {
        Vector3 targetPos;
        if(!overrideTarget){
            targetPos = targetTransform.position;
        } else {
            targetPos = targetOverridePosition;
        }
        Vector3 targetDirection = targetPos - headTransform.position;
        Vector3 aimDirection = headTransform.forward;
        float blendOut = 0f;

        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        if(targetAngle > angleLimit) { 
            blendOut += (targetAngle - angleLimit) / 50f;
        }

        float targetDistance = targetDirection.magnitude;
        if(targetDistance < distanceLimit)
        {
            blendOut += distanceLimit - targetDistance;
        }

        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return headTransform.position + direction;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!enableIK || headTransform == null || (overrideTarget && targetTransform == null))
            return;
        
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < iterations; i++){
            for (int b = 0; b < boneTransforms.Length; b++){
                Transform bone = boneTransforms[b];
                float boneWeight = humanBones[b].boneWeight * IKweight;
                AimAtTarget(bone, targetPosition, boneWeight);
            }
        }
    }
    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight){
        Vector3 aimDirection = headTransform.forward;
        Vector3 targetDirection = targetPosition - headTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion weightedRotation = Quaternion.Slerp(Quaternion.identity,aimTowards, weight);
        bone.rotation = weightedRotation * bone.rotation;
    }

    public void SetTargetTransform(Transform target){
        targetTransform = target;
    }
    public void SetAimTransform(Transform aim){
        headTransform = aim;
    }
}
