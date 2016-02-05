using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public string episodeName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadEpisode (){
		if (episodeName != null) {
			SceneManager.LoadScene (episodeName);
		} else {
			SceneManager.LoadScene ("Introduction");
		}
	}
}
