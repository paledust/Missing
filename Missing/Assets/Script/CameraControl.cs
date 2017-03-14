using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	[SerializeField] float Speed;
	[SerializeField] float AgileX;
	[SerializeField] float AgileY;
	private Quaternion tempRotation;
	void Start()
	{
		tempRotation = transform.rotation;
	}
	void Update () {
		Quaternion CamRotationAngle = Quaternion.AngleAxis(Input.GetAxis("RightStickX") * AgileX,Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("RightStickY")* AgileY,Vector3.right);
		tempRotation = Quaternion.Lerp(tempRotation, CamRotationAngle, Time.deltaTime * Speed);
		if(Quaternion.Angle(tempRotation, CamRotationAngle) <= 0.01f)
			tempRotation = CamRotationAngle;

		transform.rotation = Quaternion.Euler(tempRotation.eulerAngles.x, tempRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

		if(Input.GetAxis("RightStickY") == 0.0f)
			Debug.Log("Y STOP!");
		if(Input.GetAxis("RightStickX") == 0.0f)
			Debug.Log("X STOP!");
	}

	void CalculateAngle()
	{
		Quaternion CamRotationAngle = Quaternion.AngleAxis(Input.GetAxis("RightStickX") * AgileX,Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("RightStickY")* AgileY,Vector3.right);
		tempRotation = Quaternion.Lerp(tempRotation, CamRotationAngle, Time.deltaTime * Speed);
		if(Quaternion.Angle(tempRotation, CamRotationAngle) <= 0.01f)
			tempRotation = CamRotationAngle;
	}
}
