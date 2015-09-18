using UnityEngine;
using System.Collections;

public class dream : MonoBehaviour {
	public bool scriptActive; // change elsewhere to activate script, but make sure certain other scripts are deactivated

	Quaternion hold; // original camera rotation
	Quaternion newRotation;
	Vector3 originalPosition;
	Vector3 dreamPosition;

	bool dreaming;
	bool distracted;
	bool closeEyes;

	float time;
	float s; // speed for closing eyes

	GameObject spotlight;
	GameObject spotlight2;
	GameObject upperEyelid;
	GameObject lowerEyelid;
	GameObject pinkEle;
	changeTexture eleScript;

	GameObject rightSpot;
	GameObject leftSpot;
	bool r;
	bool l;
	Color originalAmbientLight;

	void Start () {
		scriptActive = false;

		hold = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
		newRotation = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
		originalPosition = transform.position;
		dreamPosition = new Vector3 (transform.position.x, transform.position.y + 90, transform.position.z);

		dreaming = false;
		distracted = false;
		closeEyes = false;

		time = 0;
		s = 1;

		spotlight = GameObject.Find("SpotlightDreamScene");
		spotlight2 = GameObject.Find("Spotlight2DreamScene");
		spotlight.light.enabled = false;
		spotlight2.light.enabled = false;
		pinkEle = GameObject.Find("PinkElephant");
		eleScript = pinkEle.GetComponent<changeTexture>();

		upperEyelid = GameObject.Find("upperEyelid");
		lowerEyelid = GameObject.Find("lowerEyelid");

		rightSpot = GameObject.Find("RightSpot"); //empty game objects for controlling view
		leftSpot = GameObject.Find("LeftSpot");

		originalAmbientLight = new Color(RenderSettings.ambientLight.r, RenderSettings.ambientLight.g, RenderSettings.ambientLight.b, RenderSettings.ambientLight.a);
	}

	void Update () {
		if (scriptActive) {

			// close eyes
			if (closeEyes) {
				newRotation *= Quaternion.Euler(3, 0, 1);
				transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, s*Time.deltaTime);

				if (upperEyelid.transform.localPosition.y > 1.1) {
					Vector3 tempU = upperEyelid.transform.localPosition;
					Vector3 tempL = lowerEyelid.transform.localPosition;
					tempU.y -= .05f;
					tempL.y += .05f;
					upperEyelid.transform.localPosition = tempU;
					lowerEyelid.transform.localPosition = tempL;
				}
			}
			else {
				// open eyes
				if (upperEyelid.transform.localPosition.y < 3.4) {
					Vector3 tempU = upperEyelid.transform.localPosition;
					Vector3 tempL = lowerEyelid.transform.localPosition;
					tempU.y += .08f;
					tempL.y -= .08f;
					upperEyelid.transform.localPosition = tempU;
					lowerEyelid.transform.localPosition = tempL;
				}
			}



			if (dreaming) {
				transform.position = dreamPosition;
				//if (Input.GetMouseButton(0)) {distracted=!distracted;}
				// look at elephant
				if (distracted) {
					Vector3 relativePos = pinkEle.transform.position - transform.position;
					Quaternion rotation = Quaternion.LookRotation(relativePos);
					transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2 * Time.deltaTime);
				}
				else if (r) {
					Vector3 relativePos = rightSpot.transform.position - transform.position;
					Quaternion rotation = Quaternion.LookRotation(relativePos);
					transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2 * Time.deltaTime);
				}
				else if (l) {
					Vector3 relativePos = leftSpot.transform.position - transform.position;
					Quaternion rotation = Quaternion.LookRotation(relativePos);
					transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2 * Time.deltaTime);
				}
				// look at normal
				else {
					transform.rotation = Quaternion.Slerp(transform.rotation, hold, 4 * Time.deltaTime);
				}
			}
			else {
				transform.rotation = Quaternion.Slerp(transform.rotation, hold, 4 * Time.deltaTime);
			}




			time++;
			if (time>1900) { // times need to be adjusted
				scriptActive = false;
				eleScript.walk = false;
			}
			else if (time>1750) {
				RenderSettings.ambientLight = originalAmbientLight;
				transform.position = originalPosition;
				closeEyes = false;
			}
			else if (time>1650) {
				s = 2;
				closeEyes = true;
			}
			else if (time>1550) {
				distracted = false;
			}
			else if (time>600) {
				distracted = true;
				spotlight2.light.enabled = true;
			}
			else if (time>500) {
				spotlight.light.enabled = true;
				l = false;
			}
			else if (time>390) {
				r = false;
				l = true;
			}
			else if (time>320) {
				r = true;
			}
			else if (time>250) {
				RenderSettings.ambientLight = Color.black;
				dreaming = true;
				eleScript.walk = true;
				closeEyes = false;
			}
			else if (time>65) {
				closeEyes = true;
			}
			else if (time>50) {
				closeEyes = false;
			}
			else {
				closeEyes = true;
			}


			if (Mathf.Round(time/20)%4 == 0) {
				spotlight2.light.color = Color.red;
			}
			if (Mathf.Round(time/20)%4 == 1) {
				spotlight2.light.color = Color.blue;
			}
			if (Mathf.Round(time/20)%4 == 2) {
				spotlight2.light.color = Color.green;
			}
			if (Mathf.Round(time/20)%4 == 3) {
				spotlight2.light.color = Color.yellow;
			}
		}
		else {
			transform.position = originalPosition;
			time = 0;
		}
	}
}
