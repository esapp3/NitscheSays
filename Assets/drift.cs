using UnityEngine;
using System.Collections;

public class drift : MonoBehaviour {
	public bool scriptActive;

	Vector3 textsDirection;
	Vector3 fbDirection;
	Vector3 tsquareDirection;
	
	float textsMin;
	float textsMax;
	float fbMin;
	float fbMax;
	float tsquareMin;
	float tsquareMax;

	GameObject fb;
	GameObject texts;
	GameObject tsquare;

	// Use this for initialization
	void Start () {
		scriptActive = false;
		fb = GameObject.Find ("facebook");
		texts = GameObject.Find ("texts");
		tsquare = GameObject.Find ("tsquare");

		textsMax = 18f;
		textsMin = 15f;
		fbMax = -10f;
		fbMin = -5f;
		tsquareMin = -14f;
		tsquareMax = -16f;

		textsDirection = Vector3.down;
		fbDirection = Vector3.right;
		tsquareDirection = Vector3.left;
		
		texts.rigidbody.useGravity = true;
		fb.rigidbody.useGravity = false;
		tsquare.rigidbody.useGravity = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		if(scriptActive)
		{
			mouseAction ();
				
			textMovement ();
			fbMovement ();
			tsquareMovement ();
		}
	}
	
	void mouseAction() 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider == texts.collider) {
					texts.rigidbody.velocity = new Vector3(0, 10, 0);	
					texts.audio.Play();
				}
				else if (hit.collider == fb.collider) {
					fb.rigidbody.velocity = new Vector3(-5, 0, 0);	
					fb.audio.Play();
				}
				else if (hit.collider == tsquare.collider) {
					tsquare.rigidbody.velocity = new Vector3(5, 0, 0);	
					tsquare.audio.Play();
				}
			}
			//texts.rigidbody.velocity = new Vector3(0, 10, 0);	
			//fb.rigidbody.velocity = new Vector3(-5, 0, 0);	
			//tsquare.rigidbody.velocity = new Vector3(5, 0, 0);	
		}
	}

	void textMovement()
	{
		if (textsDirection == Vector3.down) 
		{
			texts.rigidbody.useGravity=true;
			texts.rigidbody.drag = 10;
		}
		
		else if (textsDirection == Vector3.up)
		{
			texts.rigidbody.useGravity=false;
		}
		
		if (texts.rigidbody.position.y <= textsMin) 
		{
			textsDirection = Vector3.up;
		}
		if (texts.rigidbody.position.y >= textsMax) 
		{
			textsDirection = Vector3.down;
		}
	}

	void fbMovement()
	{
		if (fbDirection == Vector3.right) 
		{
			fb.rigidbody.AddForce(Vector3.right *1);
			fb.rigidbody.drag = 2;
		}
		
		else if (fbDirection == Vector3.left)
		{
			fb.rigidbody.AddForce(Vector3.left *1);
		}
		
		if (fb.rigidbody.position.x <= fbMin) 
		{
			fbDirection = Vector3.right;
		}
		if (fb.rigidbody.position.x >= fbMax) 
		{
			fbDirection = Vector3.left;
		}
	}
	
	void tsquareMovement()
	{
		if (tsquareDirection == Vector3.left) 
		{
			tsquare.rigidbody.AddForce(Vector3.left *1);
			tsquare.rigidbody.drag = 2;
		}
		
		else if (tsquareDirection == Vector3.right)
		{
			tsquare.rigidbody.AddForce(Vector3.right *1);
		}
		
		if (tsquare.rigidbody.position.x <= tsquareMin) 
		{
			tsquareDirection = Vector3.right;
		}
		if (tsquare.rigidbody.position.x >= tsquareMax) 
		{
			tsquareDirection = Vector3.left;
		}
	}
}
