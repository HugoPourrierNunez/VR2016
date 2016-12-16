using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour {

    Texture2D texture = new Texture2D(1280, 1280);
    [SerializeField]
    int tailleCrayon = 5;

    Ray ray;
    RaycastHit hit;
    Mesh mesh;

	// Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        ray = new Ray();
        hit = new RaycastHit();
        GetComponent<Renderer>().material.mainTexture = texture;
    }
	
	// Update is called once per frame
	void Update () {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*
        if (Physics.Raycast(ray, out hit))
        {*/
            GetComponent<Renderer>().material.mainTexture = texture;
            Color color = Color.blue;
            int x = (int)Input.mousePosition.x * (Screen.width / texture.width);
            int y = (int)Input.mousePosition.y * (Screen.height / texture.height);

            Vector3 posStart = Camera.main.WorldToScreenPoint(new Vector3(mesh.bounds.min.x, mesh.bounds.min.y, mesh.bounds.min.z));
            Vector3 posEnd = Camera.main.WorldToScreenPoint(new Vector3(mesh.bounds.max.x, mesh.bounds.max.y, mesh.bounds.min.z));

            int widthXMesh = (int)(posEnd.x - posStart.x);
            int widthYMesh = (int)(posEnd.y - posStart.y);


            int resultX1 = (-(int)Input.mousePosition.x * widthXMesh) / Screen.width;
            int posXTexture = (resultX1 * texture.width) / widthXMesh;

            int resultY1 = (-(int)Input.mousePosition.y * widthYMesh) / Screen.height;
            int posYTexture = (resultY1 * texture.height) / widthYMesh;

            Debug.Log("Taille Screen :" + Screen.width + "x" + Screen.height);
            Debug.Log("Mouse Position On Screen : X = " + (int)Input.mousePosition.x + " || Y = " + (int)Input.mousePosition.y);
            /*
            texture.SetPixel(posXTexture, posYTexture, color);
            texture.SetPixel(posXTexture + 1, posYTexture, color);
            texture.SetPixel(posXTexture - 1, posYTexture, color);
            texture.SetPixel(posXTexture, posYTexture + 1, color);
            texture.SetPixel(posXTexture, posYTexture - 1, color);*/

            for (int i = 0; i < tailleCrayon; i++)
            {
                for (int j = 0; j < tailleCrayon; j++)
                {
                    texture.SetPixel(posXTexture + i, posYTexture + j, color);
                }
            }

            /*
            texture.SetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y, color);
            texture.SetPixel((int)Input.mousePosition.x + 1, (int)Input.mousePosition.y, color);
            texture.SetPixel((int)Input.mousePosition.x - 1, (int)Input.mousePosition.y, color);
            texture.SetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y + 1, color);
            texture.SetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y - 1, color);
            */

            texture.Apply();
     //   }

	}

    void OnCollisionEnter(Collision collision)
    {
    }
}
