using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Head : MonoBehaviour {
	public Vector3 RANDOM_LOOK_POINT{get{return RandomLookPoint();}}
	protected Quaternion tempRotation;
	protected Vector2 mouseControlAxis;
	[SerializeField] protected float Head_RotateSpeed = 4.0f;

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
	protected void LookTo(Vector3 Look_Point){
		Quaternion lookToRotation = Quaternion.LookRotation((transform.position - Look_Point).normalized);
		tempRotation = Quaternion.Lerp(tempRotation, lookToRotation, Time.deltaTime * Head_RotateSpeed);
		transform.rotation = tempRotation;
	}
	protected void Aside(Vector3 Look_Point,Vector3 aside_Dir, float aside_Degree){
		Quaternion lookToRotation = Quaternion.LookRotation((transform.position - Look_Point - aside_Dir * aside_Degree).normalized);
		tempRotation = Quaternion.Lerp(tempRotation, lookToRotation, Time.deltaTime * Head_RotateSpeed);
		transform.rotation = tempRotation;
	}

	protected void NodeHead(float Frequency){

	}
	protected Vector3 RandomLookPoint(){
		return new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
	}
}
