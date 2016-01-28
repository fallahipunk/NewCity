using UnityEngine;
using System.Collections;

public class CardboardBackButtonQuit : MonoBehaviour {

	//used to exit the game when the back button is clicked
	// code from http://talesfromtherift.com/google-cardboard-hello-world-in-unity-5/

	void Awake() 
	{
		GetComponent<Cardboard>().OnBackButton += HandleOnBackButton;
	}

	void HandleOnBackButton ()
	{
		Application.Quit();        
	}
}
