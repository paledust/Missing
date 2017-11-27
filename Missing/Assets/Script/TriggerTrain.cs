using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrain : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	float timer = 0.0f;
	float LimitTime = 0.5f;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		if(Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)){
			if(hit.collider == GetComponent<Collider>()){
				timer += Time.deltaTime;
			}
			else timer = 0.0f;
		}
		else timer = 0.0f;

		if(timer >= LimitTime){
			
		}
	}
}
