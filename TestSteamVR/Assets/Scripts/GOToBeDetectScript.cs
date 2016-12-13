using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOToBeDetectScript : MonoBehaviour {
    Texture2D texture = new Texture2D(1280, 1280);
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        print(gameObject.name);
    }
}
