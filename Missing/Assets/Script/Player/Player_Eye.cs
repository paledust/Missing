using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Eye : Human_Eye {
	public string eyeTrigger;
	public float ShakeDegree;
	public float BlurDegree;

	[SerializeField] bool EnableBlur;
	[SerializeField] Human_Brain Brain;
	private int _EnableBlur{get{return EnableBlur ? 1 : 0;}}
	protected void BlurSight(float _BlurAmount){
		Brain.tiltShift.blurArea = _EnableBlur * Mathf.Lerp(Brain.tiltShift.blurArea, Mathf.Clamp(_BlurAmount, 4.0f,20.0f), BlurDegree * Time.deltaTime);
		Brain.tiltShift.maxBlurSize = _EnableBlur * Mathf.Lerp(Brain.tiltShift.maxBlurSize, Mathf.Clamp(_BlurAmount, 4.0f,10.0f), BlurDegree * Time.deltaTime);
		
		DoubleVisionEffect doubleVision = Brain.GetComponent<Human_Brain>().doubleVision;
		doubleVision.SET_BlurAmount(Mathf.Lerp(doubleVision.GET_BlurAmount(),  _BlurAmount/2* Random.Range(-1.0f,1.0f), ShakeDegree * Time.deltaTime)); 
	}

	protected override void _OpenUpdate(){
		SeeSomething();
		
		if(Input.GetAxis(eyeTrigger)>0.0f){
			if(Input.GetAxis(eyeTrigger) == 1.0f){
				SetStatus(Eye_State.CLOSED);
			}
			else{
				BlurSight(Input.GetAxis(eyeTrigger)*10);
				SetStatus(Eye_State.HALF);
			}
		}
		else{
			BlurSight(0.0f);
		}
	}
	protected override void _HalfUpdate(){
		SeeSomething();

		Debug.Log(Input.GetAxis(eyeTrigger));
		if(Input.GetAxis(eyeTrigger) < 1.0f){
			BlurSight(Input.GetAxis(eyeTrigger)*10);

			if(Input.GetAxis(eyeTrigger) == 0.0f){
				BlurSight(0.0f);
				SetStatus(Eye_State.OPEN);
			}
			
		}
		else{
			BlurSight(0.0f);
			SetStatus(Eye_State.CLOSED);
		}
	}
	protected override void _CloseUpdate(){
		if(Input.GetAxis(eyeTrigger)<1.0f){
			if(Input.GetAxis(eyeTrigger) == 0.0f){
				BlurSight(0.0f);
				SetStatus(Eye_State.OPEN);
			}
			else{
				BlurSight(Input.GetAxis(eyeTrigger)*10);
				SetStatus(Eye_State.HALF);
			}
		}
		else{
			BlurSight(0.0f);
		}
	}
}
