using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {


    public int hit;
    // Use this for initialization

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<AIboll>().Hitplayer(hit);
            //Destroyme();
        }
    }

    public void sethit(int _minus){
        hit = _minus;
    }



}
