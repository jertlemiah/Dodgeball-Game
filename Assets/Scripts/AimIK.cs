using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class HumanBone{
    public HumanBodyBones bone;
    [Range(0,1)]public float boneWeight = 1f;
    [Range(0,180)]public float maxAngle = 90f;
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
    [SerializeField] float rotationDuration = 1f;
    [SerializeField] HumanBone[] humanBones;
    Transform[] boneTransforms;    
    // Start is called before the first frame update
    CharacterController characterController; // need to move this elsewhere
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Animator animator = GetComponent<Animator>();
        boneTransforms = new Transform[humanBones.Length];
        for (int i = 0; i < boneTransforms.Length; i++)
        {
            boneTransforms[i] = animator.GetBoneTransform(humanBones[i].bone);
        }
    }
    public float targetAngleYaw;
    Vector3 GetTargetPosition() {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
        float blendOut = 0f;

        targetAngleYaw = Vector3.Angle(new Vector3(targetDirection.x,0,targetDirection.z), new Vector3(aimDirection.x,0,aimDirection.z));
        if(targetAngleYaw > angleLimit) { 
            // blendOut += (targetAngle - angleLimit) / 50f;
            // transform.LookAt(targetDirection,Vector3.up);
            // characterController.Move(transform.rotation * targetDirection);
            // transform.DORotate(targetDirection,rotationDuration);
            transform.DOLookAt(new Vector3(targetDirection.x,0,targetDirection.z),rotationDuration);
        }

        // float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        // if(targetAngle > angleLimit) { 
        //     blendOut += (targetAngle - angleLimit) / 50f;
        // }

        // float targetDistance = targetDirection.magnitude;
        // if(targetDistance < distanceLimit)
        // {
        //     blendOut += distanceLimit - targetDistance;
        // }

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
        // RotateBody(targetPosition);
    }
    private void RotateBody(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
        // targetAngleYaw = Vector3.Angle(new Vector3(targetDirection.x,0,targetDirection.z), new Vector3(aimDirection.x,0,aimDirection.z));
        targetAngleYaw = Vector3.Angle(targetDirection, aimDirection);
        if(targetAngleYaw > angleLimit) { 
            // blendOut += (targetAngle - angleLimit) / 50f;
            // transform.LookAt(targetDirection,Vector3.up);
            // characterController.Move(transform.rotation * targetDirection);
            // transform.DORotate(targetDirection,rotationDuration);
            transform.DOLookAt(new Vector3(targetDirection.x,0,targetDirection.z),rotationDuration);
        }
    }
    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight){
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion weightedRotation = Quaternion.Slerp(Quaternion.identity,aimTowards, weight);
        // Vector3 newBoneRotation = Quaternion.eu(weightedRotation * bone.rotation);
        // newBoneRotation
        // TODO: Need to add max angle limits, not sure how I am going to handle that
        bone.rotation = weightedRotation * bone.rotation;
        // bone.rotation = newBoneRotation;
    }

    public void SetTargetTransform(Transform target){
        targetTransform = target;
    }
    public void SetAimTransform(Transform aim){
        aimTransform = aim;
    }
}
