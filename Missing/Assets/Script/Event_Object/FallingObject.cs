using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {
	[SerializeField] BaseEventInfo eventInfo;
	public BaseEventInfo EventInfo{get {return eventInfo;}}
	// Use this for initialization
	void OnCollisionEnter(Collision collision){
		Fall_Event tempEvent = new Fall_Event(eventInfo.priority, eventInfo.AffectRange, gameObject);
		Service.eventManager.FireEvent(tempEvent);
	}
}
