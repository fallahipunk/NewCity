using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class isClickedCounter : MonoBehaviour {

	public bool allClicked = false;
	public GameObject FinalCanvas;
	public GameObject Reticle;

	public Component[] flags;
	// Use this for initialization
	void Start () {
		flags = GetComponentsInChildren<IsClickedFlag> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//checks if all interactive objects are clicked and if so displays text at end of level

	public void checkIfAllClicked (){
		allClicked = true;
		foreach (IsClickedFlag flag in flags) {
			allClicked = allClicked && flag.isClicked;
		}
		if (allClicked) {
			Debug.Log ("In The Beginning There Was Space");
			FinalCanvas.SetActive (true);
			Reticle.SetActive (false);

		}
	}
}
