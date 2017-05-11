using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : InterestingObject {
	[SerializeField] float FadeTime = 3.0f;
	// Use this for initialization
	void OnCollisionEnter(Collision collision){
		BaseObjectInfo baseInfo = new BaseObjectInfo(1,10.0f);
		setInfo(baseInfo);
		Fall_Event tempEvent = new Fall_Event(BaseInfo.priority, BaseInfo.AffectRange, gameObject);
		Service.eventManager.FireEvent(tempEvent);

		StartCoroutine(FadePriority());
	}
	IEnumerator FadePriority(){
		yield return new WaitForSeconds(FadeTime);
		setPriority(-11);
		setRange(2.0f);
	}
}
