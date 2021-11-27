using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBodyPos : MonoBehaviour
{
    [SerializeField] List<Transform> legTransforms = new List<Transform>();
    [SerializeField] private float y_offset = 1.8f;

    void Update()
    {
        Vector3 maxLegPos = new Vector3(maxXYZ(legTransforms, 'x'), maxXYZ(legTransforms, 'y'),
            maxXYZ(legTransforms, 'z'));
        Vector3 minLegPos = new Vector3(minXYZ(legTransforms, 'x'), minXYZ(legTransforms, 'y'),
            minXYZ(legTransforms, 'z'));
        Vector3 newBodyPos = Vector3.Lerp(minLegPos, maxLegPos, 0.5f);
        newBodyPos.y += y_offset;

        transform.position = newBodyPos;
    }

    private float maxXYZ(List<Transform> list, char coordinate)
    {
        if (list.Count == 0) Debug.Log("List is empty");  //exception

        float maxXYZ = float.MinValue;
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

    private float minXYZ(List<Transform> list, char coordinate)
    {
        if (list.Count == 0) Debug.Log("List is empty");  //exception

        float minXYZ = float.MaxValue;
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