using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	public Camera cameraA;
	public Camera cameraB;
	public Camera cameraCA;
	public Camera cameraCB;

	public Material cameraMatA;
	public Material cameraMatB;
	public Material cameraMatCA;
	public Material cameraMatCB;

	// Use this for initialization
	void Start () {
		if (cameraA.targetTexture != null)
		{
			cameraA.targetTexture.Release();
		}
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatA.mainTexture = cameraA.targetTexture;

		if (cameraB.targetTexture != null)
		{
			cameraB.targetTexture.Release();
		}
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatB.mainTexture = cameraB.targetTexture;

		if (cameraCA.targetTexture != null)
		{
			cameraCA.targetTexture.Release();
		}
		cameraCA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatCA.mainTexture = cameraCA.targetTexture;

		if (cameraCB.targetTexture != null)
		{
			cameraCB.targetTexture.Release();
		}
		cameraCB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatCB.mainTexture = cameraCB.targetTexture;
	}
	
}
