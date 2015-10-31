using UnityEngine;
using System.Collections;

public class terraincontroller : MonoBehaviour {
    private Vector3 click;
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click = Input.mousePosition;
            print(click);
        }
    }
}
