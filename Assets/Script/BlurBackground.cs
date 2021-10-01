using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurBackground : MonoBehaviour
{
    public Camera blurCamera;
    public Material blurMaterial;

    void Awake()
    {
        if (blurCamera.targetTexture != null) {
            blurCamera.targetTexture.Release();
        }
        blurCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 1);
        blurMaterial.SetTexture("_RendTex", blurCamera.targetTexture);
    }

    public void Blur() {
        blurCamera.enabled = true;
    }
}
