using UnityEngine;
using System.Collections;

// attached to each object that needs to be clicked before the text at the end of each level appears

public class IsClickedFlag : MonoBehaviour {

	public bool isClicked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickObject(){
		isClicked = true;
	}
}
