using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{
    [SerializeField] Transform homeTransform;
    [SerializeField] float wantStepDistance;
    [SerializeField] float stepDuration;
    public GameObject sphere2;
    private bool isMoving;
    public bool IsMoving { get; set; }

    private void Start()
    {
        Ray ray2 = new Ray(transform.position, Vector3.down);
        RaycastHit hitLeg;

        if (Physics.Raycast(ray2, out hitLeg))
        {
            Debug.DrawRay(transform.position, Vector3.down * 5);
            sphere2.transform.position = hitLeg.point;
            //  frontLeftLeg.transform.position = hitLeg.point;


        }
    }

    void Update()
    {


        
        if (isMoving) return;
        else
        {
            //transform.position = sphere2.transform.position;
            float distanceFromHome = Vector3.Distance(transform.position, homeTransform.position);

            Debug.Log(distanceFromHome);

            if (distanceFromHome > wantStepDistance)
            {
                StartCoroutine(MoveLeg());
            }
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
        }
        while (timeElapsed < stepDuration);
       
    }
}
