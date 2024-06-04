using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera[] cameraB;
    public Material[] cameraMatb;
    void Start()
    {
        for (int i = 0; i < cameraB.Length; i++)
        {
            if (cameraB[i].targetTexture != null)
            {
                cameraB[i].targetTexture.Release();
            }
            cameraB[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMatb[i].mainTexture = cameraB[i].targetTexture;
        }
    }
}