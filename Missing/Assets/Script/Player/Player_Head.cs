using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Head : Human_Head {

	// Use this for initialization
	protected override void Start () {
		tempRotation = transform.rotation;
	}
	
	// Update is called once per frame
	protected override void Update () {
		ProcessMouse();
		RotateControl(GetControlX() * AgileX, GetControlY() * AgileY, Speed);
	}
	protected void ProcessMouse(){
		mouseControlAxis.x += Input.GetAxis("Mouse X");
		mouseControlAxis.y += Input.GetAxis("Mouse Y");
	}
}
