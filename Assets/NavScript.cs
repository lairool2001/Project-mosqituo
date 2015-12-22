using UnityEngine;
using System.Collections;

public class NavScript : MonoBehaviour {
    public Transform TargetObject=null;

	// Use this for initialization
	void Start () {
        if (TargetObject != null)
        {
            GetComponent<NavMeshAgent>().destination = TargetObject.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
