using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Eye : MonoBehaviour {
	public enum Eye_State{
		CLOSED,
		HALF,
		OPEN
	}
	public GameObject SeenObject{get; private set;}
	protected Ray ray;
	protected RaycastHit rayhit;
	protected Eye_State eye_State;
	// Use this for initialization
	void Start () {
		SetStatus(Eye_State.OPEN);
	}
	// Update is called once per frame
	void Update () {
		switch (eye_State){
			case Eye_State.CLOSED:
				CloseUpdate();
				break;
			case Eye_State.HALF:
				HalfUpdate();
				break;
			case Eye_State.OPEN:
				OpenUpdate();
				break;
			default:
				break;
		}
	}
	public Eye_State GetStatus(){return eye_State;}
	public void SetStatus(Eye_State _eye_State){
		eye_State = _eye_State;
	}
	void CloseUpdate(){
		_CloseUpdate();
	}
	void HalfUpdate(){
		_HalfUpdate();
	}
	void OpenUpdate(){
		_OpenUpdate();
	}
	protected virtual void _OpenUpdate(){
	}
	protected virtual void _HalfUpdate(){
	}
	protected virtual void _CloseUpdate(){
	}
	protected void SeeSomething(){
		ChangingObject();
		if(SeenObject != null)
			SeenObject.GetComponent<NPC_FSM_Head>().BE_LOOKED(true, gameObject);
		ChangingObject();
	}
	private Collider EyeRaycast(){
		ray = new Ray(transform.position, transform.rotation * Vector3.forward);
		if(Physics.Raycast(ray.origin,ray.direction, out rayhit,500.0f))
		{
			return rayhit.collider;
		}
		return null;
	}
	private void ChangingObject(){
		if(EyeRaycast() !=null && EyeRaycast().GetComponent<NPC_FSM_Head>() && EyeRaycast().gameObject != SeenObject){
			if(SeenObject != null){
				SeenObject.GetComponent<NPC_FSM_Head>().BE_LOOKED(false, null);
			}
			SeenObject = EyeRaycast().gameObject;
		}
		else if(EyeRaycast() == null){
			if(SeenObject != null){
				SeenObject.GetComponent<NPC_FSM_Head>().BE_LOOKED(false, null);
				SeenObject = null;
			}
		}
	}
}
