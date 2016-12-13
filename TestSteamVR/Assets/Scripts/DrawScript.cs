using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour {

    Texture2D texture = new Texture2D(1280, 1280);

    Ray ray;
    RaycastHit hit;

	// Use this for initialization
    void Start()
    {
        ray = new Ray();
        hit = new RaycastHit();
        GetComponent<Renderer>().material.mainTexture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = ((x & y) != 0 ? Color.white : Color.gray);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {*/
            GetComponent<Renderer>().material.mainTexture = texture;
            Color color = Color.blue;
            int x = (int)Input.mousePosition.x * (Screen.width / texture.width);
            int y = (int)Input.mousePosition.y * (Screen.height / texture.height);
            texture.SetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y, color);
            texture.SetPixel((int)Input.mousePosition.x+1, (int)Input.mousePosition.y, color);
            texture.SetPixel((int)Input.mousePosition.x-1, (int)Input.mousePosition.y, color);
            texture.SetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y+1, color);
            texture.SetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y-1, color);
            texture.Apply();
      //  }

	}
}
