using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorMovement : MonoBehaviour
{
    public GameObject original;
    public GameObject[] palos;
    RotationsArms RotArm;



    private void Start()
    {

        RotArm = original.GetComponent<RotationsArms>();
    }

    void Update ()
    {
        //transform.localRotation = original.transform.localRotation;
        for (int i = 0; i < RotArm.Palos.Length;i++) {
            palos[i].transform.rotation = RotArm.Palos[i].transform.rotation;
            /* if (RotArm.Palos[i].transform.rotation.x < maxAngle)
             {
                 palos[i].transform.rotation = new Quaternion (RotArm.Palos[i].transform.rotation.x, palos[i].transform.rotation.y, palos[i].transform.rotation.z,1);
             }
             if (RotArm.Palos[i].transform.rotation.y < maxAngle)
             {
                 palos[i].transform.rotation = new Quaternion(palos[i].transform.rotation.x, RotArm.Palos[i].transform.rotation.y, palos[i].transform.rotation.z, 1);
             }
             if (RotArm.Palos[i].transform.rotation.z < maxAngle)
             {
                 palos[i].transform.rotation = new Quaternion(palos[i].transform.rotation.x, palos[i].transform.rotation.y, RotArm.Palos[i].transform.rotation.z, 1);
             }*/

        }
    }
}
