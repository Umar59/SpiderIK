using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{
    [SerializeField] Transform homeTransform;
    [SerializeField] float wantStepDistance;
    [SerializeField] float stepDuration;
    private bool isMoving;
    public bool IsMoving { get; set; }

    void Update()
    {
        if (isMoving) return;

        float distanceFromHome = Vector3.Distance(transform.position, homeTransform.position);

        //Debug.Log(distanceFromHome);

        if (distanceFromHome > wantStepDistance)
        {
            StartCoroutine(MoveLeg());
        }
    }

    IEnumerator MoveLeg()
    {
        Quaternion startRot = transform.rotation;
        Vector3 startPos = transform.position;

        Quaternion endRot = homeTransform.transform.rotation;
        Vector3 endPos = homeTransform.transform.position;

        float timeElapsed = 0;
        float normalizedTime;

        do
        {
            timeElapsed += Time.deltaTime;
            normalizedTime = timeElapsed / stepDuration;

            transform.position = Vector3.Lerp(startPos, endPos, normalizedTime);
            transform.rotation = Quaternion.Slerp(startRot, endRot, normalizedTime);


            yield return null;
        } while (timeElapsed < stepDuration);
    }
}