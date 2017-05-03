using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : InterestingObject {
	private float timer;
	private bool Trigger = false;
	[SerializeField] float FadeTime = 3.0f;
	// Use this for initialization
	void OnCollisionEnter(Collision collision){
		BaseObjectInfo baseInfo = new BaseObjectInfo(1,10.0f);
		setInfo(baseInfo);
		Fall_Event tempEvent = new Fall_Event(BaseInfo.priority, BaseInfo.AffectRange, gameObject);
		Service.eventManager.FireEvent(tempEvent);
		Trigger = true;
	}
	void Update(){
		if(Trigger){
			timer += Time.deltaTime;
			if(timer >= FadeTime){
				Trigger = false;
				setPriority(-1);
				setRange(2.0f);
			}
		}
	}
}
