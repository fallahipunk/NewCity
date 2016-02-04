using UnityEngine;
using System.Collections;

public class OrbitParent : MonoBehaviour {
	public Vector3 direction;
	public int speed;
	// Use this for initialization
	void Start () {

	}

	// this function is used for event triggers
	public void callOrbit (){
		StartCoroutine("orbitAroundParent");
	}

	IEnumerator orbitAroundParent (){
		// once the coroutine starts it goes into this infinite loop that orbits the planet 
		while (true) { 
			transform.RotateAround (transform.parent.position, direction, speed * Time.deltaTime);
			yield return null;
		}
	}


}
