using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationsArms : MonoBehaviour {


    public Vector3[] axis;
    public GameObject[] Palos;
    public GameObject EndEffector;
    public float[] Angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(PositionEndDefector(axis, Palos));
        }
        else
        {
            PositionEndDefector(axis, Palos);
        }

    }


    Vector3 PositionEndDefector(Vector3[] angles, GameObject[] palos) {


        
        for (int i = 0; i < angles.Length; i++) {
            palos[i].transform.eulerAngles = new Vector3(0, 0, 0);
            palos[i].transform.Rotate(angles[i], Angle[i]);
            for (int j = i-1; j >= 0; j--) {
                palos[i].transform.Rotate(angles[j], Angle[j]);
            }
        }
        Vector3 FinalPosition = EndEffector.transform.position;

        //FinalPosition = this.transform.position



        return FinalPosition;
    }
}
