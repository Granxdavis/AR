using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationEjercicio6 : MonoBehaviour {

    Animator m_Anim;
    bool shake = false;

	public GameObject umbrella;//Coger el paraguas
	Vector3 positionUmbrella;//Posicion del paraguas al principio
	public GameObject mano;
	Vector3 delayUmbrella = new Vector3 (0.406f, -0.513f, 0.585f);//Diferencia para encajar bien el paraguas a la mano
	public GameObject accelerationGravityArrow;
    public GameObject accelerationFrictionArrow;
    public GameObject velocityArrow;

	// Use this for initialization
	void Start () {
        m_Anim = GetComponent<Animator>(); //Cojemos el animator
		umbrella.GetComponent<Rigidbody>().useGravity = false;//Hacemos que no le afecte la gravedad
		positionUmbrella = umbrella.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        print(Vector3.Distance(umbrella.transform.position, mano.transform.position + delayUmbrella));
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_Anim.Play(0);
            umbrella.transform.parent = null;
            umbrella.transform.eulerAngles = new Vector3(0, 0, 0);
            umbrella.transform.position = positionUmbrella;
            shake = true;
			umbrella.GetComponent<Rigidbody>().useGravity = true;
			umbrella.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
            
        }
        else {
            shake = false;
        }
        m_Anim.SetBool("shake", shake);

        print(Vector3.Distance(umbrella.transform.position, mano.transform.position + delayUmbrella));

		if (Vector3.Distance (umbrella.transform.position, mano.transform.position+delayUmbrella) <= 0.75f) {
		
			umbrella.GetComponent<Rigidbody>().useGravity = false;
			umbrella.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			umbrella.gameObject.transform.SetParent (mano.transform);
			umbrella.gameObject.transform.localPosition = delayUmbrella;
			accelerationFrictionArrow.GetComponent<MeshRenderer> ().enabled = false;
            accelerationGravityArrow.GetComponent<MeshRenderer>().enabled = false;
            velocityArrow.GetComponent<MeshRenderer>().enabled = false;

        }
		ForceArrows ();

    }


	void ForceArrows(){

        int reduceSizeArrow = 50;

        /// FLECHA FRICCION ///
		Vector3 velocityFallSquared = new Vector3(	Mathf.Pow(umbrella.GetComponent<Rigidbody>().velocity.x,2),Mathf.Pow(umbrella.GetComponent<Rigidbody>().velocity.y,2),Mathf.Pow(umbrella.GetComponent<Rigidbody>().velocity.z,2));

		float frictionForce = Mathf.Sqrt (Mathf.Pow (velocityFallSquared.x, 2) + Mathf.Pow (velocityFallSquared.y, 2) + Mathf.Pow (velocityFallSquared.z, 2));

		float arrowFrictionForce = frictionForce / reduceSizeArrow; //Dividimos entre un valor arbitrario para que las flechas no sean enormes la magnitud de la fuerza de fricción

		accelerationFrictionArrow.transform.localScale = new Vector3( accelerationFrictionArrow.transform.localScale.x, accelerationFrictionArrow.transform.localScale.y, arrowFrictionForce);
		//print ("arrowFrictionForce = "+ arrowFrictionForce); //la fuerza de friccion es proporcional a la velocidad de caida al cuadrado

        umbrella.GetComponent<Rigidbody>().AddForce(0, arrowFrictionForce, 0, ForceMode.Impulse);

        /// FLECHA GRAVEDAD ///

        float absolutGravityForce = 9.81f;

        float arrowGravityForce = absolutGravityForce / reduceSizeArrow;

        accelerationGravityArrow.transform.localScale = new Vector3(accelerationGravityArrow.transform.localScale.x, accelerationGravityArrow.transform.localScale.y, arrowGravityForce);
        //print("arrowGravityForce = "+ arrowGravityForce);

        /// FLECHA VELOCIDAD ///

        //La flecha velocidad esta un poco movida para no solaparse con la de acceleración
        float absoluteVelocityY = Mathf.Abs(umbrella.GetComponent<Rigidbody>().velocity.y);

        float arrowVelocity = absoluteVelocityY / reduceSizeArrow;

        velocityArrow.transform.localScale = new Vector3(velocityArrow.transform.localScale.x, velocityArrow.transform.localScale.y, arrowGravityForce);
        //print("arrowVelocity = " + arrowVelocity);
    }

}
