using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	[SerializeField] float Speed;
	[SerializeField] float AgileX;
	[SerializeField] float AgileY;
	[SerializeField] float ObserveFOV;
	[SerializeField] float ZoomSpeed;
	[SerializeField] Shader Shader_DoubleVision;
	public DoubleVisionEffect doubleVision{get; private set;}
	private Quaternion tempRotation;
	private float startFOV;
	void Start(){
		tempRotation = transform.rotation;
		startFOV = Camera.main.fieldOfView;

		doubleVision = new DoubleVisionEffect(Shader_DoubleVision);
	}
	void Update () {
		RotateControl(Input.GetAxis("RightStickX") * AgileX, Input.GetAxis("RightStickY") * AgileY, Speed);
		Observe(AxisToInput(-Input.GetAxis("LeftStickY"), ObserveFOV, startFOV), ZoomSpeed);
	}

	void OnRenderImage(RenderTexture src, RenderTexture dst){
		doubleVision._OnRenderImage(src, dst);
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
	public void Observe(float ZoomDegree, float _ZoomSpeed){
		if(Mathf.Abs(ZoomDegree - Camera.main.fieldOfView) > 0.1f)
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, ZoomDegree, _ZoomSpeed * Time.deltaTime);
		else
			Camera.main.fieldOfView = ZoomDegree;
	}
	public void Observe(float ZoomDegree, float MaxFOV, float MinFOV, float ZoomSpeed){
		if(Mathf.Abs(ZoomDegree - Camera.main.fieldOfView) > 0.1f)
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, ZoomDegree, ZoomSpeed * Time.deltaTime);
		else
			Camera.main.fieldOfView = ZoomDegree;
	}
}
