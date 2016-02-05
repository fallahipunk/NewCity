using UnityEngine;
using System.Collections;

public class SolarSystemHover : MonoBehaviour {

	public Material hoverMaterial;
	public Material PlanetMaterial;
	public Material SunMaterial;

	Renderer[] planetsRenderers;


	// Use this for initialization
	void Start () {
		planetsRenderers = GetComponentsInChildren<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void swichMaterialIn(){
		foreach (Renderer r in planetsRenderers) {
			r.material = hoverMaterial;
		}
	}

	public void swichMaterialOut (){
		int i = 0; 
		foreach (Transform child in transform) {
			Debug.Log (child.name);
			if (child.name == "StarSphere" || child.name == "Particle System") {
				child.gameObject.GetComponent<Renderer>().material = SunMaterial;
			} else if (child.name == "CollisionCube") {
				//r.material = SunMaterial;
			} else {
				child.gameObject.GetComponent<Renderer>().material = PlanetMaterial;
			}
		}
	}

}
