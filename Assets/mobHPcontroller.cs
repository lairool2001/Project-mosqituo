using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mobHPcontroller : MonoBehaviour {
    public GameObject target;
    public Text ShowHPText;
    public Vector3 Offset;
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
        else
        {
            ShowHPText.transform.position = Camera.main.WorldToScreenPoint(target.transform.position) + Offset;
        }
	}
}
