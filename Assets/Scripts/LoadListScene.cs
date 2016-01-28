using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadListScene : MonoBehaviour {

	//function to be called when the "Begin" button in the intro is clicked
	public void BeginIsClicked (){
		SceneManager.LoadScene ("Episode1");
	}
}
