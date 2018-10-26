using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnterFullScreen()
    {
        StartCoroutine(HideActionBarWithTimeout());
    }

    public GameObject actionBarPanel;

    private IEnumerator HideActionBarWithTimeout()
    {
        actionBarPanel.GetComponent<Animator>().Play("ActionBarDisappear");
        yield return new WaitForSeconds(3);
        actionBarPanel.GetComponent<Animator>().Play("ActionBarAppear");
    }

}
