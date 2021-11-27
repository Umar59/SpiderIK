using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class LegMover : MonoBehaviour
{
    [SerializeField] Transform homeTransform;
    [SerializeField] float wantStepDistance;
    [SerializeField] float stepDuration;
    [SerializeField] float stepOvershootFraction;
    private bool isMoving = false;
    public bool IsMoving { get; set; }

    public void TryMove()
    {
        if (isMoving) return;

        float distanceFromHome = Vector3.Distance(transform.position, homeTransform.position);

        if (distanceFromHome > wantStepDistance)
        {
            StartCoroutine(MoveLeg());
        }
    }

    IEnumerator MoveLeg()
    {
        isMoving = true;
        Vector3 startPoint = transform.position;
        Quaternion startRot = transform.rotation;

        Quaternion endRot = homeTransform.rotation;

        Vector3 towardHome = (homeTransform.position - transform.position);
        float overshootDistance = wantStepDistance * stepOvershootFraction;
        Vector3 overshootVector = towardHome * overshootDistance;
        overshootVector = Vector3.ProjectOnPlane(overshootVector, Vector3.up);

        Vector3 endPoint = homeTransform.position + overshootVector;

        Vector3 centerPoint = (startPoint + endPoint) / 2;
        centerPoint += homeTransform.up * Vector3.Distance(startPoint, endPoint) / 2f;

        float timeElapsed = 0;
        do
        {
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / stepDuration;
            normalizedTime = Easing.InOutCubic(normalizedTime);
            transform.position =
                Vector3.Lerp(
                    Vector3.Lerp(startPoint, centerPoint, normalizedTime),
                    Vector3.Lerp(centerPoint, endPoint, normalizedTime),
                    normalizedTime
                );

            transform.rotation = Quaternion.Slerp(startRot, endRot, normalizedTime);

            yield return null;
        }
        while (timeElapsed < stepDuration);

        isMoving = false;
    }
}