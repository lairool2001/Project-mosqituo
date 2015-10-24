using UnityEngine;
using System.Collections;

public class mobHPcontroller : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Mob");
    }
	
	// Update is called once per frame
	void Update () {
        if (!target.gameObject)
        {
            Destroy(gameObject);
        }
	}
}
