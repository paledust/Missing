using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMe : MonoBehaviour {
	PhoneObj PhoneToCall;
	public void Call(){
		PhoneToCall = GameObject.Find("MyPhone").GetComponent<PhoneObj>();
		PhoneToCall.Ring();
	}
}
