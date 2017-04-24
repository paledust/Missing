using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
public class BlinkEye : MonoBehaviour {
	public float ShakeDegree;
	public float BlurDegree;

	[SerializeField] Human_Brain Brain;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("LeftTrigger") < 1.0f)
			BlurSight(Input.GetAxis("LeftTrigger")*10);
		else
			BlurSight(0.0f);
	}

	void BlurSight(float _BlurAmount)
	{
		DoubleVisionEffect doubleVision = Brain.GetComponent<Human_Brain>().doubleVision;
		Brain.tiltShift.blurArea = Mathf.Lerp(Brain.tiltShift.blurArea, _BlurAmount, BlurDegree * Time.deltaTime);
		Brain.tiltShift.maxBlurSize = Mathf.Lerp(Brain.tiltShift.maxBlurSize, _BlurAmount, BlurDegree * Time.deltaTime);
		doubleVision.SET_BlurAmount(Mathf.Lerp(doubleVision.GET_BlurAmount(),  _BlurAmount/2* Random.Range(-1.0f,1.0f), ShakeDegree*Time.deltaTime)); 
	}
}
