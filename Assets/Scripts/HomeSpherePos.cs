using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HomeSpherePos : MonoBehaviour
{
    [SerializeField] private Transform legHome;
    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitLeg;

        if (Physics.Raycast(ray, out hitLeg))
        {
            Debug.DrawRay(transform.position, Vector3.down * 5);
            legHome.transform.position = hitLeg.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        

        if (Physics.Raycast(ray, out RaycastHit hitLeg))
        {
            Debug.DrawRay(transform.position, Vector3.down * 5);
            Vector3 destination = hitLeg.point;
            
           legHome.transform.position = destination;;
            
        }
    }
}
