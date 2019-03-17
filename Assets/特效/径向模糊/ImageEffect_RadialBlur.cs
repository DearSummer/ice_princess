﻿using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
[AddComponentMenu ("PengLu/ImageEffect/RadialBlur")]
public class ImageEffect_RadialBlur : MonoBehaviour {
	#region Variables
	public Shader RadialBlurShader = null;
	private Material RadialBlurMaterial = null;
	// private RenderTextureFormat rtFormat = RenderTextureFormat.Default;

	[Range(0.0f, 1.0f)]
	public float SampleDist = 0.91f;

	[Range(1.0f, 5.0f)]
	public float SampleStrength = 3.76f;


	#endregion


    void Start()
    {
        this.enabled = false;
        FindShaders();
        CheckSupport();
        CreateMaterials();
    }

    void FindShaders () {
		if (!RadialBlurShader) {
			RadialBlurShader = Shader.Find("PengLu/ImageEffect/Unlit/RadialBlur");
		}
	}

	void CreateMaterials() {
		if(!RadialBlurMaterial){
			RadialBlurMaterial = new Material(RadialBlurShader);
			RadialBlurMaterial.hideFlags = HideFlags.HideAndDontSave;	
		}
	}

	bool Supported(){
		return (SystemInfo.supportsImageEffects && SystemInfo.supportsRenderTextures && RadialBlurShader.isSupported);
		// return true;
	}


	bool CheckSupport() {
		if(!Supported()) {
			enabled = false;
			return false;
		}
		// rtFormat = SystemInfo.SupportsRenderTextureFormat (RenderTextureFormat.RGB565) ? RenderTextureFormat.RGB565 : RenderTextureFormat.Default;
		return true;
	}


	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
	{	
		#if UNITY_EDITOR
			FindShaders ();
			CheckSupport ();
			CreateMaterials ();	
		#endif

		if(SampleDist != 0 && SampleStrength != 0){

			int rtW = sourceTexture.width/8;
	        int rtH = sourceTexture.height/8;


	        RadialBlurMaterial.SetFloat ("_SampleDist", SampleDist);
	        RadialBlurMaterial.SetFloat ("_SampleStrength", SampleStrength);	


	        RenderTexture rtTempA = RenderTexture.GetTemporary (rtW, rtH, 0,RenderTextureFormat.Default);
            rtTempA.filterMode = FilterMode.Bilinear;

            Graphics.Blit (sourceTexture, rtTempA);

            RenderTexture rtTempB = RenderTexture.GetTemporary (rtW, rtH, 0,RenderTextureFormat.Default);
            rtTempB.filterMode = FilterMode.Bilinear;
            // RadialBlurMaterial.SetTexture ("_MainTex", rtTempA);
            Graphics.Blit (rtTempA, rtTempB, RadialBlurMaterial,0);

            RadialBlurMaterial.SetTexture ("_BlurTex", rtTempB);
       		Graphics.Blit (sourceTexture, destTexture, RadialBlurMaterial,1);

            RenderTexture.ReleaseTemporary(rtTempA);
            RenderTexture.ReleaseTemporary(rtTempB);
 
		}

		else{
			Graphics.Blit(sourceTexture, destTexture);
			
		}
		
		
	}
	
}
