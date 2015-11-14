using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

    public GameObject mob;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Destroyme();
        }
    }
    void Destroyme()
    {
        Destroy(gameObject);
    }



}
