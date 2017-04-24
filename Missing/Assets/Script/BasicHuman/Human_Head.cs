using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Head : MonoBehaviour {
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
	protected void RotateTo(Transform _ToTrans){
		transform.LookAt(_ToTrans);
	}
	protected void LookTo(Vector3 Look_Point){
		transform.LookAt(Look_Point);
	}
	protected Vector3 RandomLookPoint(){
		return new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
	}
}
