using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : InterestingObject {
	[SerializeField] float FadeTime = 3.0f;
	// Use this for initialization
	void OnCollisionEnter(Collision collision){
		Fall_Event tempEvent = new Fall_Event(_BaseInfo.priority, _BaseInfo.AffectRange, gameObject);
		Service.eventManager.FireEvent(tempEvent);

		StartCoroutine(FadePriority());
	}
	IEnumerator FadePriority(){
		yield return new WaitForSeconds(FadeTime);
		setPriority(-11);
		setRange(2.0f);
	}
}
