using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour {

    Texture2D texture;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    int tailleCrayon = 5;

    Ray ray;
    RaycastHit hit;
    Mesh mesh;
    Renderer myRenderer;

	// Use this for initialization
    void Start()
    {
        texture = new Texture2D(1280, 1280);
        mesh = GetComponent<MeshFilter>().mesh;
        ray = new Ray();
        hit = new RaycastHit();
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.mainTexture = texture;
    }
	
	// Update is called once per frame
	void Update () {
        
            
     //   }

	}

    void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Index")
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(collision.collider.gameObject.transform.position);

            myRenderer.material.mainTexture = texture;
            Color color = Color.blue;

            Vector3 posStart = Camera.main.WorldToScreenPoint(new Vector3(mesh.bounds.min.x, mesh.bounds.min.y, mesh.bounds.min.z));
            Vector3 posEnd = Camera.main.WorldToScreenPoint(new Vector3(mesh.bounds.max.x, mesh.bounds.max.y, mesh.bounds.min.z));

            int widthXMesh = (int)(posEnd.x - posStart.x);
            int widthYMesh = (int)(posEnd.y - posStart.y);

            int resultX1 = (-(int)screenPos.x * widthXMesh) / Screen.width;
            int posXTexture = (resultX1 * texture.width) / widthXMesh;

            int resultY1 = (-(int)screenPos.y * widthYMesh) / Screen.height;
            int posYTexture = (resultY1 * texture.height) / widthYMesh;

            Debug.Log("Taille Screen :" + Screen.width + "x" + Screen.height);
            Debug.Log("Mouse Position On Screen : X = " + (int)screenPos.x + " || Y = " + (int)screenPos.y);

            for (int i = 0; i < tailleCrayon; i++)
            {
                for (int j = 0; j < tailleCrayon; j++)
                {
                    texture.SetPixel(posXTexture + i, posYTexture + j, color);
                }
            }

            texture.Apply(); 
        }
        
    }

    void OnMouseOver()
    {
        /*
        GetComponent<Renderer>().material.mainTexture = texture;
        Color color = Color.blue;

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

        for (int i = 0; i < tailleCrayon; i++)
        {
            for (int j = 0; j < tailleCrayon; j++)
            {
                texture.SetPixel(posXTexture + i, posYTexture + j, color);
            }
        }

        texture.Apply();*/
    }
}
