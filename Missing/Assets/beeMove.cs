using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeMove : MonoBehaviour {
	[SerializeField]float MoveSpeed = 1.0f;
	[SerializeField]float Sharpness;
	Vector3 direction;
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		float x = Mathf.PerlinNoise(timer, 0.1f);
		float y = Mathf.PerlinNoise(timer, 0.4f);
		float z = Mathf.PerlinNoise(timer, 0.9f);
		direction = new Vector3(x,y,z);
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.PerlinNoise(timer + Time.deltaTime * Sharpness, 0.1f);
		x = x*2-1;
		float y = Mathf.PerlinNoise(timer + Time.deltaTime * Sharpness, 0.4f);
		y = y*2-1;
		float z = Mathf.PerlinNoise(timer + Time.deltaTime * Sharpness, 0.9f);
		z = z*2-1;
		direction = new Vector3(x,y,z);

		transform.position += direction * MoveSpeed * 0.01f;
	}
}
