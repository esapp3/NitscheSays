using UnityEngine;
using System.Collections;

public class changeTexture : MonoBehaviour {
	float time;
	float MAX_TIME = 12*14;
	Vector3 original;
	Vector3 newTransform;
	public Texture p00;
	public Texture p01;
	public Texture p02;
	public Texture p03;
	public Texture p04;
	public Texture p05;
	public Texture p06;
	public Texture p07;
	public Texture p08;
	public Texture p09;
	public Texture p10;
	public Texture p11;

	public bool walk;
	Color originalColor;

	void Start () {
		time = 0;
		original = transform.position;
		walk = false;
		originalColor = renderer.material.color;
	}

	void Update () {
		if (walk) {
			renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a);
			time++;
			newTransform = transform.position;
			newTransform.x -= 0.1f;
			transform.position = newTransform;
			if (time > MAX_TIME) {
				time = 0;
			}
			if (time>0 && time<(MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p00;
			}
			else if (time>(MAX_TIME/12) && time<(2*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p01;
			}
			else if (time>(2*MAX_TIME/12) && time<(3*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p02;
			}
			else if (time>(3*MAX_TIME/12) && time<(4*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p03;
			}
			else if (time>(4*MAX_TIME/12) && time<(5*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p04;
			}
			else if (time>(5*MAX_TIME/12) && time<(5*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p05;
			}
			else if (time>(6*MAX_TIME/12) && time<(7*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p06;
			}
			else if (time>(7*MAX_TIME/12) && time<(8*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p07;
			}
			else if (time>(8*MAX_TIME/12) && time<(9*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p08;
			}
			else if (time>(9*MAX_TIME/12) && time<(10*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p09;
			}
			else if (time>(10*MAX_TIME/12) && time<(11*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p10;
			}
			else if (time>(11*MAX_TIME/12) && time<(12*MAX_TIME/12)) 
			{
				transform.renderer.material.mainTexture = p11;
			}
		}
		else {
			renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.0f);
		}
	}





}
