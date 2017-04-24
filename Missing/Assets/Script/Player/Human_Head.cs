using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Head : MonoBehaviour {
	[SerializeField] protected float Speed;
	[SerializeField] protected float AgileX;
	[SerializeField] protected float AgileY;

	protected Quaternion tempRotation;
	protected Vector2 mouseControlAxis;
	virtual protected void Start(){
		tempRotation = transform.rotation;
	}
	virtual protected void Update () {
	}

	public void RotateControl(float AngleX, float AngleY, float _Speed){
		Quaternion CamRotationAngle = FromAxisToRotate(AngleX, Vector3.up) * FromAxisToRotate(AngleY, Vector3.right);
		tempRotation = Quaternion.Lerp(tempRotation, CamRotationAngle, Time.deltaTime * _Speed);
		if(Quaternion.Angle(tempRotation, CamRotationAngle) <= 0.01f)
			tempRotation = CamRotationAngle;

		transform.rotation = Quaternion.Euler(tempRotation.eulerAngles.x, tempRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
	}

	protected Quaternion FromAxisToRotate(float AngleAxis, Vector3 RotateAxis){
		return Quaternion.AngleAxis(AngleAxis,RotateAxis);
	}

	protected float AxisToInput(float TriggerAxis, float MaxFOV, float MinFOV){
		float tempFOV = (MaxFOV - MinFOV) * TriggerAxis + MinFOV;

		return tempFOV;
	}
	protected float GetControlX(){return Input.GetAxis("RightStickX") + mouseControlAxis.x;}
	protected float GetControlY(){return Input.GetAxis("RightStickY") - mouseControlAxis.y;}
	protected void ProcessMouse(){
		mouseControlAxis.x += Input.GetAxis("Mouse X");
		mouseControlAxis.y += Input.GetAxis("Mouse Y");
	}
}
