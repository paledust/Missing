using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLine: MonoBehaviour {
	private Ray ray;
	private RaycastHit rayhit;

	void Update()
	{
		ray = new Ray(transform.position, transform.rotation * Vector3.forward);
		if(Physics.Raycast(ray.origin,ray.direction, out rayhit,500.0f))
		{
			Debug.Log(rayhit.collider.gameObject.name);
		}
	}
}
