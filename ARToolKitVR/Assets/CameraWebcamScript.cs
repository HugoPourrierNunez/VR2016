using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWebcamScript : MonoBehaviour {

    private GUITexture BackgroundTexture;
    private WebCamTexture CameraTexture;
    // Use this for initialization
    void Start () {

        BackgroundTexture = gameObject.AddComponent<GUITexture>();
        BackgroundTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        //set up camera
        WebCamDevice[] devices = WebCamTexture.devices;
        string backCamName = "";
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Device:" + devices[i].name + "IS FRONT FACING:" + devices[i].isFrontFacing);

            if (!devices[i].isFrontFacing)
            {
                backCamName = devices[i].name;
            }
        }

        CameraTexture = new WebCamTexture(backCamName, 10000, 10000, 30);
        CameraTexture.Play();
        BackgroundTexture.texture = CameraTexture;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
