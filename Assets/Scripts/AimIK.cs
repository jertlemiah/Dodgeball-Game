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
    [Range(0,1)] [SerializeField] float IKweight = 1f;
    public Transform targetTransform;
    public Transform aimTransform;
    [SerializeField] int iterations = 10;
    public float angleLimit = 90f;
    public float distanceLimit = 1f;
    [SerializeField] HumanBone[] humanBones;
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
    }

    Vector3 GetTargetPosition() {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
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
        return aimTransform.position + direction;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(aimTransform == null || targetTransform == null)
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
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion weightedRotation = Quaternion.Slerp(Quaternion.identity,aimTowards, weight);
        bone.rotation = weightedRotation * bone.rotation;
    }

    public void SetTargetTransform(Transform target){
        targetTransform = target;
    }
    public void SetAimTransform(Transform aim){
        aimTransform = aim;
    }
}
