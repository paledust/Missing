using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingObject : MonoBehaviour {
	[SerializeField] BaseEventInfo eventInfo;
	public BaseEventInfo EventInfo{get {return eventInfo;}}
	[SerializeField] Vector3 moveDir;
	[SerializeField] float Speed;
	void Start(){
	}
	
	// Update is called once per frame
	void Update () {
		Shift_Event tempEvent = new Shift_Event(eventInfo.priority, eventInfo.AffectRange, gameObject);
		Service.eventManager.FireEvent(tempEvent);
	}
}
