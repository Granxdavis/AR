using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
	public int exercise = 1;

    Quaternion offset, offset2;

    // Use this for initialization
    void Start ()
    {
        offset = Quaternion.Inverse(transform.rotation) * target1.rotation;
        target2.rotation = this.transform.rotation;
        offset2 = Quaternion.Inverse(offset);
    }

    void Update()
    {
        switch(exercise)
        {
            case 1:
            {
                    // float signedAngle = Vector3.SignedAngle(target1.forward, target2.forward, Vector3.up);
                    // print(signedAngle);
                   // float angulo = Vector3.Angle(target1.forward, target2.forward);
                    Vector3 EjeX = Vector3.Cross(transform.right, target1.right).normalized;
                    float angleX = -Mathf.Acos(Vector3.Dot(transform.right, target1.right)) * Mathf.Rad2Deg;

                    Vector3 EjeY = Vector3.Cross(transform.up, target1.up).normalized;
                    float angleY = -Mathf.Acos(Vector3.Dot(transform.up, target1.up)) * Mathf.Rad2Deg;

                    target1.Rotate(EjeX, angleX, Space.World);
                    target1.Rotate(EjeY, angleY, Space.World);
                       

                } break;

          

            case 2:
            {
                    target1.rotation = Quaternion.Slerp(target1.rotation, transform.rotation, Time.time * 0.02f);
             } break;

            case 3:
            {
                    target1.rotation = transform.rotation * offset;
            } break;

            case 4:
            {

                    target1.rotation = transform.rotation * offset;
                    target2.rotation = target1.transform.rotation * offset2;

                } break;
        }
    }
}
