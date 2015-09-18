using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	Camera startCam;
	Camera studentCamera;
	Camera endCam;
	Camera winCam;

	AudioSource snapeSound;
	AudioSource peanutsSound;
	AudioSource anyoneSound;
	AudioSource narutoSound;

	GameObject simonSaysSpotlight;
	GameObject simonRedGameLight;
	GameObject simonBlueGameLight;
	GameObject simonYellowGameLight;
	GameObject simonGreenGameLight;

	// Use this for initialization
	void Start () {

		startCam = GameObject.Find ("StartCamera").GetComponent<Camera>() as Camera;
		studentCamera = GameObject.Find ("Student Camera").GetComponent<Camera>() as Camera;
		endCam = GameObject.Find ("EndCamera").GetComponent<Camera> () as Camera;
		winCam = GameObject.Find("WinCamera").GetComponent<Camera>() as Camera;

		snapeSound = GameObject.Find ("snapeSound").GetComponent<AudioSource>() as AudioSource;
		peanutsSound = GameObject.Find ("peanutsSound").GetComponent<AudioSource>() as AudioSource;
		anyoneSound = GameObject.Find ("anyoneSound").GetComponent<AudioSource>() as AudioSource;
		narutoSound = GameObject.Find ("narutoSound").GetComponent<AudioSource>() as AudioSource;

		startCam.enabled = true;
		endCam.enabled = false;
		studentCamera.enabled = false;
		winCam.enabled = false;

		anyoneSound.enabled = true;
		peanutsSound.enabled = false;
		snapeSound.enabled = false;
		narutoSound.enabled = true;

		simonSaysSpotlight = GameObject.Find("SimonSaysLight");
		simonRedGameLight = GameObject.Find("SimonSaysLightRed");
		simonBlueGameLight = GameObject.Find("SimonSaysLightBlue");
		simonYellowGameLight = GameObject.Find("SimonSaysLightYellow");
		simonGreenGameLight = GameObject.Find("SimonSaysLightGreen");

	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKey("UpArrow")){

		}
		else if {

		}
		else if {}
		else if {}*/
		//Camera studentCamera = GameObject.Find ("Student Camera").GetComponent<Camera>() as Camera;
		//Camera startCam = GameObject.Find ("StartCamera").GetComponent<Camera>() as Camera;
		//Camera endCam = GameObject.Find ("EndCamera").GetComponent<Camera> () as Camera;

		/*if (Input.GetKey ("return")) {
				startCam.enabled = false;
				studentCamera.enabled = true;
				endCam.enabled = false;

				anyoneSound.enabled = false;
				narutoSound.enabled = false;
				peanutsSound.enabled = true;
				snapeSound.enabled = false;
		}*/

		/*if (Input.GetKey ("e")) {
				startCam.enabled = false;
				studentCamera.enabled = false;
				endCam.enabled = true;
		}*/

		/*if (Input.GetKey ("d")) {
			anyoneSound.enabled = false;
			narutoSound.enabled = false;
			peanutsSound.enabled = false;
			snapeSound.enabled = true;
		}*/
	}

	public void switchMain() {
		startCam.enabled = false;
		studentCamera.enabled = true;
		endCam.enabled = false;
		
		anyoneSound.enabled = false;
		narutoSound.enabled = false;
		peanutsSound.enabled = true;
		snapeSound.enabled = false;

		peanutsSound.Play ();
	}

	public void switchEnd() {
		startCam.enabled = false;
		studentCamera.enabled = false;
		endCam.enabled = true;
	}

	public void dreamSound() {
		anyoneSound.enabled = false;
		narutoSound.enabled = false;
		peanutsSound.enabled = false;
		snapeSound.enabled = true;
	}

	public void switchWin() {
		startCam.enabled = false;
		studentCamera.enabled = false;
		winCam.enabled = true;
	}
}
