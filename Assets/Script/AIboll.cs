using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIboll : MonoBehaviour
{
    public NavMeshAgent player;
    public GameObject target;
    public Transform atk;
    public const int AI_ATTACK_DISTANCE = 2;
    private float timer;
    public int hp = 5;
    public ValueShowOut aValueShowOut;

    // Use this for initialization
    void Start()
    {
        //player = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Mob");
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ChooseNearestMob();
        if (target.gameObject)
            followmob();
         /*transform.LookAt(target.transform); //保持物件一直面朝target
         if (Vector3.Distance(transform.position, target.transform.position) > AI_ATTACK_DISTANCE)
             transform.Translate(Vector3.forward * Time.deltaTime * 3);*/
         //player.destination = target.position;
    }

    private void ChooseNearestMob()
    {
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mob")
        {                        
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //print("Boll attack");
                Instantiate(atk, transform.position, transform.rotation);
                timer = 1;
            }
            /*if (other.gameObject.CompareTag("atkzon"))
            {
                Destroyme();
            }*/
        }
        else if (other.gameObject.CompareTag("atkzon"))
        {
            int hurt=3;
            hp -= hurt;
            ValueShowOut.Born(gameObject, hurt);
            if (hp <= 0)
            {
                Destroyme();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "mob")

            timer = 1.5f;
    }

    void Destroyme()
    {
        Destroy(gameObject);
    }

    void followmob()
    {
        transform.LookAt(target.transform); //保持物件一直面朝target
        if (Vector3.Distance(transform.position, target.transform.position) > AI_ATTACK_DISTANCE)
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
    }
}