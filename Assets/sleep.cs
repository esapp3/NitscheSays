using UnityEngine;
using System.Collections;

public class sleep : MonoBehaviour {
	public bool scriptActive; // change elsewhere to activate script, but make sure certain other scripts are deactivated

	Quaternion hold; // original camera rotation
	Quaternion newRotation;

	bool fallAsleep;
	bool closeEyes;

	float time;
	float SLEEP_TIME;
	float startTime;

	GameObject upperEyelid;
	GameObject lowerEyelid;

	void Start () {
		scriptActive = false;

		hold = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
		newRotation = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);

		fallAsleep = false;
		closeEyes = false;

		time = 0;
		SLEEP_TIME = 200; // time value to prevent falling asleep too often
		startTime = 0;

		upperEyelid = GameObject.Find("upperEyelid");
		lowerEyelid = GameObject.Find("lowerEyelid");
	}

	void Update () {
		if (scriptActive) {
			// CHECK FOR WAKE UP CONDITION
			if (Input.mousePosition.y > Screen.height*0.8) {
				time = 0;
				fallAsleep = false;
				closeEyes = false;
			}

			if (fallAsleep) {
				// camera tilt until startTime+50: stops camera from continuing to rotate 50 loops after falling asleep
				if (time<(startTime+50)) {
					// rotates camera
					newRotation *= Quaternion.Euler(3, 0, 1);
					transform.rotation= Quaternion.Slerp(transform.rotation, newRotation,2 * Time.deltaTime);
				}

				if (closeEyes) {
					// close eyes
					if (upperEyelid.transform.localPosition.y > 1.1) {
						Vector3 tempU = upperEyelid.transform.localPosition;
						Vector3 tempL = lowerEyelid.transform.localPosition;
						tempU.y -= .05f;
						tempL.y += .05f;
						upperEyelid.transform.localPosition = tempU;
						lowerEyelid.transform.localPosition = tempL;
					}
				}
			}
			else {
				// return camera to original position
				transform.rotation = Quaternion.Slerp (transform.rotation, hold, 4 * Time.deltaTime);
				newRotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
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

			time++;
			if (time > SLEEP_TIME && Random.value > 0.95 && !fallAsleep) {
				fallAsleep = true;
				closeEyes = true;
				startTime = time;
			}
		}// end scriptActive
	}
}