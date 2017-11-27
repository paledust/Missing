using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom_Event;
using Event = Custom_Event.Event;
public class ShiftingObject : InterestingObject {
	public void StartToShift(){
		Long_Range_Event tempEvent = new Long_Range_Event(BaseInfo.priority, gameObject);
		Service.eventManager.FireEvent(tempEvent);
	}
}
