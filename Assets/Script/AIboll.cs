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
        if (target.gameObject)
            followmob();
         /*transform.LookAt(target.transform); //保持物件一直面朝target
         if (Vector3.Distance(transform.position, target.transform.position) > AI_ATTACK_DISTANCE)
             transform.Translate(Vector3.forward * Time.deltaTime * 3);*/
         //player.destination = target.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Mob")
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

            Destroyme();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Mob")

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