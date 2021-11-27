using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LegUpdateCor : MonoBehaviour
{
    [SerializeField] LegMover frontLeftLegStepper;
    [SerializeField] LegMover frontRightLegStepper;
    [SerializeField] LegMover middleLeftLegStepper;
    [SerializeField] LegMover middleRightLegStepper;
    [SerializeField] LegMover rearLeftLegStepper;
    [SerializeField] LegMover rearRightLegStepper;

    private void Awake()
    {
        StartCoroutine(LegUpdateCoroutine());
    }

    IEnumerator LegUpdateCoroutine()
    {
        while (true)
        {
            do
            {
                                                                                    Debug.Log(frontLeftLegStepper.IsMoving);
                                                                                    Debug.Log(rearRightLegStepper.IsMoving);
                frontLeftLegStepper.TryMove();                                  
                rearRightLegStepper.TryMove();                                  
                middleLeftLegStepper.TryMove();                                 
                yield return null;                                  
                                                                                    Debug.Log(frontLeftLegStepper.IsMoving);
                                                                                    Debug.Log(rearRightLegStepper.IsMoving);
            } while (rearRightLegStepper.IsMoving || frontLeftLegStepper.IsMoving || middleLeftLegStepper.IsMoving);

            do
            {
                frontRightLegStepper.TryMove();
                rearLeftLegStepper.TryMove();
                middleRightLegStepper.TryMove();
                yield return null;
            } while (rearLeftLegStepper.IsMoving || frontRightLegStepper.IsMoving || middleRightLegStepper.IsMoving);
        }
    }
}
