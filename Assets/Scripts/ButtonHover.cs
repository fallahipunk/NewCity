using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ButtonHover : MonoBehaviour {
	public Image  hoverImage;
	private Text buttonText;
	// Use this for initialization
	//this script is to be attached to buttons that have 2 children, child 0 first being the Text, and child 1 the Hover Image
	void Start () {
		hoverImage = GetComponentsInChildren<Image>()[1];
		buttonText = GetComponentsInChildren<Text>()[0];

		//make hover image invisible at the beginning

		hoverImage.canvasRenderer.SetAlpha (0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void swichTextColorIn (){
		StartCoroutine("fadeButtonTextIn");
		StopCoroutine("fadeButtonTextOut");
	}

	public void swichTextColorOut (){
		StartCoroutine("fadeButtonTextOut");
		StopCoroutine("fadeButtonTextIn");
	}

	public void buttonImageIn (){
		StartCoroutine("fadeHoverImgIn");
		StopCoroutine("fadeHoverImgOut");
		
	}

	public void buttonImageOut (){
		StartCoroutine("fadeHoverImgOut");
		StopCoroutine("fadeHoverImgIn");
	}


	// Below is a list of coroutines called for fading the button in and out
	//These are not included in the functions above because the event trigger needs them to be Public Void



	// This Coroutine fades the text of a button from white to gray when hoverd over.
	public IEnumerator fadeButtonTextIn(){
		for (float f=buttonText.color.r; f>.38f; f-=.01f) {
				buttonText.color = new Color (f, f, f);
				yield return null;
		}
	}

	//This Coroutine fades the text of a button from gray back to white when no longer hovered
	public IEnumerator fadeButtonTextOut(){
		for (float f=buttonText.color.r; f<=1f;f +=.01f){
			buttonText.color = new Color (f, f, f);
			yield return null;
		}
	
	}

	// This Coroutine fades the hover image in when hoverd over.
	public IEnumerator fadeHoverImgIn(){
		for (float f = hoverImage.canvasRenderer.GetAlpha (); f < 1; f += .1f) {
			hoverImage.canvasRenderer.SetAlpha (f);
			Debug.Log (f);
			yield return null;
		}
	}

	//Fades hover image out when button is no longer hovered
	public IEnumerator fadeHoverImgOut(){
		for (float f = hoverImage.canvasRenderer.GetAlpha (); f > 0f; f -= .1f) {
			hoverImage.canvasRenderer.SetAlpha (f);
			Debug.Log (f);
			yield return null;
		}
	}


}// end class
