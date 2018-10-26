using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleConstraints : MonoBehaviour
{
    public bool active;

    [Range(0.0f, 180.0f)]
    public float maxAngle;

    [Range(0.0f, 180.0f)]
    public float minAngle;

    public Transform parent;
    public Transform child;

    void Start()
    {
    }

    float w;
    Vector3 axis;

    void LateUpdate()
    {
        if (active)
        {
            transform.rotation.ToAngleAxis(out w, out axis);
            if (w > maxAngle) {
                transform.rotation = Quaternion.AngleAxis(maxAngle, axis);
   
            }

            if (w < minAngle) {
                transform.rotation = Quaternion.AngleAxis(maxAngle, axis);
            }



        }
    }

    //add auxiliary functions, if needed, below




}
