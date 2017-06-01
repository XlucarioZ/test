using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector3 direction;
	float speed = 10.0f;
	float aliveTimer = 0.0f;
	float aliveDuration = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(direction * Time.deltaTime * speed);

		aliveTimer += Time.deltaTime;
		if(aliveTimer > aliveDuration)
		{
			Destroy(gameObject);
		}
	}
}
