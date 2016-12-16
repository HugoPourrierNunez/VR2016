using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOverSurfaceScript : MonoBehaviour {


    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        ray = new Ray();
        hit = new RaycastHit();
	}

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
        }
    }
}
