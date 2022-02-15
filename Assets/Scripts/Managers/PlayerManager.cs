using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] ControllerBrainPair[] controllerBrainPairs;
    [Serializable]public struct ControllerBrainPair
    {
        public UnitManipulator playerController;
        public PlayerBrain playerBrain;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}