using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Avoid : NPC_FSM_Head {
	[SerializeField] Vector2 pauseRange;
	[SerializeField] float AsideDegree;
	private float avoid_timer = 0.0f;
	private Vector3 tempAside = Vector3.zero;
	protected override void STARING_Update(){
		if(Looker != null){
			avoid_timer += Time.deltaTime;
			if(avoid_timer > Random.Range(pauseRange.x, pauseRange.y)){
				tempAside = RANDOM_LOOK_POINT;
				avoid_timer = 0.0f;
			}
			Aside(Looker.transform.position,tempAside, 2.0f);
		}
	}
}
