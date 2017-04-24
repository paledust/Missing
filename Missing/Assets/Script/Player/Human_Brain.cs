using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
public class Human_Brain : MonoBehaviour {
	public DoubleVisionEffect doubleVision{get; private set;}
	[SerializeField] Shader Shader_DoubleVision;
	[SerializeField] float ObserveFOV;
	[SerializeField] float ZoomSpeed;
	private float startFOV;
	public TiltShift tiltShift{get; private set;}

	// Use this for initialization
	void Start () {
		doubleVision = new DoubleVisionEffect(Shader_DoubleVision);
		startFOV = GetComponentInChildren<Camera>().fieldOfView;
		tiltShift = GetComponent<TiltShift>();
	}
	
	// Update is called once per frame
	void Update () {
		Observe(AxisToInput(Mathf.Clamp(-Input.GetAxis("LeftStickY"),0,1), ObserveFOV, startFOV), ZoomSpeed);
	}
	void OnRenderImage(RenderTexture src, RenderTexture dst){
		doubleVision._OnRenderImage(src, dst);
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
}
