using UnityEngine;
using System.Collections;

public class bollatkzon : MonoBehaviour {

    private AIboll atk;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("mob"))
        {            
            Destroyme();
        }
    }

    void Destroyme()
    {
        Destroy(gameObject);
    }
}
