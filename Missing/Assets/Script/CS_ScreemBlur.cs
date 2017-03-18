using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ScreemBlur : MonoBehaviour {
	public Shader targetShader_Blur;
	// Use this for initialization
	void Start () {
		if(targetShader_Blur)
			Camera.main.SetReplacementShader(targetShader_Blur, "RenderType");
	}

	
}
