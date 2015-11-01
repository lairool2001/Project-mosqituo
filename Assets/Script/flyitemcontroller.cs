using UnityEngine;
using System.Collections;

public class flyitemcontroller : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    // Use this for initialization
    void Start()
    {
        ChooseNearestMob();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
            followmob();
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mob")
        {
            Destroy(gameObject);
        }
    }
    void followmob()
    {
        transform.LookAt(target.transform);
       // transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void ChooseNearestMob()
    {
        target = GameObject.Find("Mob");
        var AllMob = mobcontroller.FindObjectsOfType<mobcontroller>();
        if (AllMob.Length > 0)
        {
            float Nearest = Vector2.Distance(AllMob[0].transform.position, transform.position);
            target = AllMob[0].gameObject;
            for (int i = 1; i < AllMob.Length; ++i)
            {
                float d = Vector2.Distance(AllMob[i].transform.position, transform.position);
                if (d < Nearest)
                {
                    d = Nearest;
                    target = AllMob[i].gameObject;
                }
            }
        }
    }
}