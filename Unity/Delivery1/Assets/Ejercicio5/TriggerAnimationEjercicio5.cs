using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationEjercicio5 : MonoBehaviour {

    Animator m_Anim;
    bool shake = false;
    

	// Use this for initialization
	void Start () {
        m_Anim = GetComponent<Animator>(); //Cojemos el animator
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.B))
        {
            shake = true;
        }
        else {
            shake = false;
        }
        m_Anim.SetBool("shake", shake);
        


    }
}
