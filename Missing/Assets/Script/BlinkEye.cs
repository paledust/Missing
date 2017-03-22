using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
public class BlinkEye : MonoBehaviour {
	public float ShakeDegree;
	public float BlurDegree;
	private TiltShift tiltShift;
	private DoubleVisionEffect doubleVision;

	// Use this for initialization
	void Start () {
		doubleVision = GetComponent<DoubleVisionEffect>();
		tiltShift = GetComponent<TiltShift>();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("LeftTrigger") < 1.0f)
			BlurSight(Input.GetAxis("LeftTrigger")*10);
		else
			BlurSight(0.0f);
		
	}

	void BlurSight(float _BlurAmount)
	{
		tiltShift.blurArea = Mathf.Lerp(tiltShift.blurArea, _BlurAmount, BlurDegree * Time.deltaTime);
		tiltShift.maxBlurSize = Mathf.Lerp(tiltShift.maxBlurSize, _BlurAmount, BlurDegree * Time.deltaTime);
		doubleVision.blurAmount = Mathf.Lerp(doubleVision.blurAmount,  _BlurAmount/2* Random.Range(-1.0f,1.0f), ShakeDegree*Time.deltaTime);
	}
}
