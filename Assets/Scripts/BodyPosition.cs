using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    public GameObject sphere;
    public GameObject sphere2;
    public GameObject frontLeftLeg;
    private Vector3 distance = new Vector3();
    RaycastHit hitLeg;
    void Start()
    {
        Ray ray2 = new Ray(frontLeftLeg.transform.position, Vector3.down);
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

        //fix the leg to the ground










        distance = sphere.transform.position - sphere2.transform.position;



        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * 5);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.DrawRay(transform.position, Vector3.down * 5);

            sphere.transform.position = hit.point;
            Debug.Log(distance.magnitude);
        }

        //if (distance.magnitude < 2f)
        //{
        //    sphere2.transform.position += new Vector3(2f, 0f, 0f);
        //    //frontLeftLeg.transform.position += new Vector3(2f, 0f, 0f);
        //}
        //else if (distance.magnitude > 3.8f)
        //{
        //    Vector3 direction = (sphere.transform.position - sphere2.transform.position).normalized;

        //    sphere2.transform.position += direction*1.5f;
        //}
       // else
        //{

            frontLeftLeg.transform.position = sphere2.transform.position;


       // }

    }
}
