using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingObject : InterestingObject {
	public void StartToShift(){
		Long_Range_Event tempEvent = new Long_Range_Event(BaseInfo.priority, gameObject);
		Service.eventManager.FireEvent(tempEvent);
	}
}
