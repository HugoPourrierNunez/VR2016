using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamCubeScript : MonoBehaviour {

    [SerializeField]
    Renderer myRenderer;

	// Use this for initialization
	void Start () {
        WebCamTexture webcamTexture = new WebCamTexture(WebCamTexture.devices[1].name);
        myRenderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
