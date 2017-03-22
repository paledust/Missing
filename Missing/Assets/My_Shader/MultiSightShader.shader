Shader "Custom/MultiSightShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Displace("Displace", Vector) = (0.1, 0.1, 0.0, 0.0)
		_BlurAmount("_BlurAmount", Range(0.0, 1.0)) = 0.0
	}
	SubShader
		{
			Pass
			{
				ZTest Always
				Cull Off
				ZWrite Off
				Fog{Mode Off}

				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#include "UnityCG.cginc"
//				#include "Colorful.cginc"

				sampler2D _MainTex;
				fixed2 _Displace;
				float _BlurAmount;

				fixed4 frag(v2f_img i): Color
				{
					fixed4 c = tex2D(_MainTex, i.uv);

					c += tex2D(_MainTex, i.uv + half2(_Displace.x * _BlurAmount, _Displace.y * _BlurAmount)) * 1.0f;
					// c += tex2D(_MainTex, i.uv + half2(_Displace.x * 24, _Displace.y * 24)) * 0.4f;
					// c += tex2D(_MainTex, i.uv + half2(_Displace.x * 32, _Displace.y * 32)) * 0.2f;
					
					c *= 0.5f;

					return c;
				}

				ENDCG
			}
		}

		FallBack off
}
