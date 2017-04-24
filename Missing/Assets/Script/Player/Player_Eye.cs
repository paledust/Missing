using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Eye : Human_Eye {
	public string eyeTrigger;
	public float ShakeDegree;
	public float BlurDegree;

	[SerializeField] Human_Brain Brain;
	protected void BlurSight(float _BlurAmount){
		DoubleVisionEffect doubleVision = Brain.GetComponent<Human_Brain>().doubleVision;
		Brain.tiltShift.blurArea = Mathf.Lerp(Brain.tiltShift.blurArea, _BlurAmount, BlurDegree * Time.deltaTime);
		Brain.tiltShift.maxBlurSize = Mathf.Lerp(Brain.tiltShift.maxBlurSize, _BlurAmount, BlurDegree * Time.deltaTime);
		doubleVision.SET_BlurAmount(Mathf.Lerp(doubleVision.GET_BlurAmount(),  _BlurAmount/2* Random.Range(-1.0f,1.0f), ShakeDegree * Time.deltaTime)); 
	}

	protected override void _OpenUpdate(){
		Debug.Log(Input.GetAxis("LeftTrigger"));
		if(Input.GetAxis("LeftTrigger") < 1.0f)
			BlurSight(Input.GetAxis("LeftTrigger")*10);
		else
			BlurSight(0.0f);
	}
}
