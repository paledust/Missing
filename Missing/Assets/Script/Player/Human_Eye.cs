using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Eye : MonoBehaviour {
	public enum Eye_State{
		Closed,
		Half,
		Open
	}
	private Ray ray;
	private RaycastHit rayhit;
	protected Eye_State eye_State;
	// Use this for initialization
	void Start () {
		SetStatus(Eye_State.Open);
	}
	// Update is called once per frame
	void Update () {
		switch (eye_State){
			case Eye_State.Closed:
				CloseUpdate();
				break;
			case Eye_State.Half:
				HalfUpdate();
				break;
			case Eye_State.Open:
				OpenUpdate();
				break;
			default:
				break;
		}
	}
	public void SetStatus(Eye_State _eye_State){
		eye_State = _eye_State;
	}
	void CloseUpdate(){
	}
	void HalfUpdate(){
		ray = new Ray(transform.position, transform.rotation * Vector3.forward);
		if(Physics.Raycast(ray.origin,ray.direction, out rayhit,500.0f))
		{
			Debug.Log(rayhit.collider.gameObject.name);
		}
	}
	void OpenUpdate(){
		ray = new Ray(transform.position, transform.rotation * Vector3.forward);
		if(Physics.Raycast(ray.origin,ray.direction, out rayhit,500.0f))
		{
			Debug.Log(rayhit.collider.gameObject.name);
		}
		_OpenUpdate();
	}
	protected virtual void _OpenUpdate(){
	}
	protected virtual void _HalfUpdate(){
	}
	protected virtual void _CloseUpdate(){
	}
}
