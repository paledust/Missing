using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToShift : MonoBehaviour {
	private bool ifTrigger = false;
	// Use this for initialization
	void Update () {
		if(!ifTrigger){
			GetComponent<ShiftingObject>().StartToShift();
			ifTrigger = true;
		}
	}
}
