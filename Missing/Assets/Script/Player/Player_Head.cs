using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Head : Human_Head {
	[SerializeField] protected float Speed;
	[SerializeField] protected float RangeX;
	[SerializeField] protected float RangeY;
	[SerializeField] protected bool ActiveMouse = true;
	private int mouseFlag{
		get{
			if(ActiveMouse)
				return 1;
			return 0;
		}
	}
	// Use this for initialization
	protected override void Start () {
		tempRotation = transform.rotation;
	}
	
	// Update is called once per frame
	protected override void Update () {
		ProcessMouse();
		RotateControl(GetControlX() * RangeX, GetControlY() * RangeY, Speed);
	}
	protected float GetControlX(){return Input.GetAxis("RightStickX") + mouseControlAxis.x;}
	protected float GetControlY(){return Input.GetAxis("RightStickY") - mouseControlAxis.y;}
	protected void ProcessMouse(){
		mouseControlAxis.x += mouseFlag * Input.GetAxis("Mouse X");
		mouseControlAxis.y += mouseFlag * Input.GetAxis("Mouse Y");
	}
}
