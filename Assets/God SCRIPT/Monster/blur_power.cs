using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blur_power : MonoBehaviour
{

    [Range(0, 1f)]
    public float blurPower = 0.1f;

    [Range(0, 1)]
    public float blurLerp = 0.5f;

    public int downScale = 2;

    public Vector2 blurCenter = new Vector2(0.5f, 0.5f);

    public Material mat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture rt1 = RenderTexture.GetTemporary(source.height >> downScale, source.width >> downScale, 0, source.format);
        RenderTexture rt2 = RenderTexture.GetTemporary(source.height >> downScale, source.width >> downScale, 0, source.format);
        Graphics.Blit(source, rt1);

        mat.SetFloat("_blurPower", blurPower);
        mat.SetVector("_blurCenter", blurCenter);
        Graphics.Blit(rt1, rt2, mat, 0);

        mat.SetTexture("_blurTex", rt2);
        mat.SetFloat("_blurLerp", blurLerp);
        Graphics.Blit(source, destination, mat, 1);

        RenderTexture.ReleaseTemporary(rt1);
        RenderTexture.ReleaseTemporary(rt2);

    }
}
