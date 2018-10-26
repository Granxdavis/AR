using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


    enum Exercise {Ejercicio3, Ejercicio5, Ejercicio6};
    Exercise Ejercicio = Exercise.Ejercicio6;


    public GameObject[] TargetPoints;

    bool zoom = false;

    float alphaLerp = 0;

	// Use this for initialization
	void Start () {
       //transform.position = TargetPoints[0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A)) {

            Ejercicio = Exercise.Ejercicio3;
            zoom = true;
            alphaLerp = 0;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {

            Ejercicio = Exercise.Ejercicio5;
            zoom = true;
            alphaLerp = 0;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            Ejercicio = Exercise.Ejercicio6;
            zoom = true;
            alphaLerp = 0;
        }

        switch (Ejercicio) {

            case Exercise.Ejercicio3:
                transform.position = TargetPoints[0].transform.position;

                break;
            case Exercise.Ejercicio5:


                transform.position = TargetPoints[1].transform.position;
                break;
            case Exercise.Ejercicio6:

				transform.position = TargetPoints[2].transform.position;
                break;
        }

        if (zoom) {
            Zoom();
        }

	}


    void Zoom() {

        float speed = 2;
        float vistaDeManos = 3;

        if (alphaLerp <= vistaDeManos)
        {
            this.transform.position = Vector3.Lerp(TargetPoints[(int)Ejercicio].transform.position, TargetPoints[(int)Ejercicio].transform.position + new Vector3(2.5f, 0, 0), alphaLerp);
            alphaLerp += Time.deltaTime * speed;

        }
        else {
            this.transform.position = Vector3.Lerp(TargetPoints[(int)Ejercicio].transform.position + new Vector3(2.5f, 0, 0), TargetPoints[(int)Ejercicio].transform.position, alphaLerp - vistaDeManos);
            alphaLerp += Time.deltaTime * speed;

        }
        if (alphaLerp >= vistaDeManos + 1) {
            zoom = false;
        }
    }
}
