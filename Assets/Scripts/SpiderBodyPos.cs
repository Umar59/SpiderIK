using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBodyPos : MonoBehaviour
{
    [SerializeField] List<Transform> legTransforms = new List<Transform>();


    void Update()
    {
        //Vector3 maxLegPos = new Vector3(FindMaxXYZ(legTransforms, 'x'), FindMaxXYZ(legTransforms, 'y') + 3f, FindMaxXYZ(legTransforms, 'z'));
        //Vector3 minLegPos = new Vector3(FindMinXYZ(legTransforms, 'x'), FindMinXYZ(legTransforms, 'y') + 3f, FindMinXYZ(legTransforms, 'z'));
        //Vector3 newBodyPos = Vector3.Lerp(minLegPos, maxLegPos, 0.5f);
        //newBodyPos.y += 2.5f;

        //Debug.Log(maxLegPos + " Min: " + minLegPos);
        float maxY = FindMaxXYZ(legTransforms, 'y');
        Debug.Log(maxY);
       //transform.position = newBodyPos;
    }

    public float FindMaxXYZ(List<Transform> list, char coordinate)
    {
        if (list.Count == 0)
        {
            Debug.Log("List is empty");
            //exception
        }

        float maxXYZ = 1;
        switch (coordinate)
        {
            case 'x':
                foreach (Transform type in list)
                {
                    if (type.position.x > maxXYZ)
                    {
                        maxXYZ = type.position.x;
                    }
                }
                break;

            case 'y':
                foreach (Transform type in list)
                {
                    if (type.position.y > maxXYZ)
                    {
                        maxXYZ = type.position.y;
                    }
                }
                break;

            case 'z':
                foreach (Transform type in list)
                {
                    if (type.position.z > maxXYZ)
                    {
                        maxXYZ = type.position.z;
                    }
                }
                break;
        }


        return maxXYZ;
    }
    public float FindMinXYZ(List<Transform> list, char coordinate)
    {
        if (list.Count == 0)
        {
            Debug.Log("List is empty");
            //exception
        }

        float minXYZ = 0;
        switch (coordinate)
        {
            case 'x':
                foreach (Transform type in list)
                {
                    if (type.position.x < minXYZ)
                    {
                        minXYZ = type.position.x;
                    }
                }
                break;

            case 'y':
                foreach (Transform type in list)
                {
                    if (type.position.y < minXYZ)
                    {
                        minXYZ = type.position.y;
                    }
                }
                break;

            case 'z':
                foreach (Transform type in list)
                {
                    if (type.position.z < minXYZ)
                    {
                        minXYZ = type.position.z;
                    }
                }
                break;
        }


        return minXYZ;
    }
}
