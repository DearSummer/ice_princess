Shader "Custom/NewSurfaceShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_blurTex("blurTex",2D) = "white"{}
	}
		CGINCLUDE
		sampler2D _MainTex;
	sampler2D _blurTex;
	float _blurPower;
	float2 _blurCenter;
	float _blurLerp;
	float4 _MainTex_TexelSize;
#include "UnityCG.cginc"
#define deifu_count 6

	fixed4 frag_blur(v2f_img i) :SV_Target
	{
		float2 dir = i.uv - _blurCenter;
		float4 colorout;
		for (int j = 0; j < deifu_count; j++)
		{
			float2 uv_s = i.uv + _blurPower * j*dir;
			colorout += tex2D(_MainTex,uv_s);
		}
		colorout = colorout / 6;
		return colorout;
	}

		struct v2f_lerp
	{
		float4 pos:POSITION;
		float2 uv1:TEXCOORD0;
		float2 uv2:TEXCOORD1;
	};

	v2f_lerp vert_lerp(appdata_img v)
	{
		v2f_lerp o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv1 = v.vertex.xy;
		o.uv2 = v.vertex.xy;
		return o;
	}

	float4 frag_lerp(v2f_lerp i) :SV_Target
	{
		float2 dir = i.uv1 - _blurCenter;
		float dis = length(dir);
		float4 mainTex = tex2D(_MainTex,i.uv1);
		float4 blurTex = tex2D(_blurTex,i.uv2);
		//return blurTex;
		return lerp(mainTex,blurTex,dis*_blurLerp * 2);
	}
		ENDCG
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
			LOD 100

			Pass
		{
			ZWrite Off
			ZTest Off
			Cull Off

			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag_blur



			ENDCG
		}

			Pass
		{
			ZWrite Off
			ZTest Off
			Cull Off

			CGPROGRAM

			#pragma vertex vert_lerp
			#pragma fragment frag_lerp

			ENDCG
		}
	}
}
