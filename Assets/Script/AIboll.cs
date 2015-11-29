using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIboll : MonoBehaviour
{
    //public NavMeshAgent player;
    public GameObject target;
    public Transform atk;
    public Transform faratk;
    //public const int AI_ATTACK_DISTANCE = 2;                    //近戰距離
    //public const int AI_RENGER_DISTANCE = 5;                   //遠攻距離
    private float timer;
    public float hp = 5;
    public float renger = 2;                            //攻擊距離
    public int hurt;
    public int type;                                                                 // 0 是近戰，1 是遠攻，2 是撿東西
    public float runspeed = 1.5f;
    public float atkspeed = 1.5f;

    private bool targeted = false;
    public float FindTime, FineTimeLength = 0.5f;
    public MobManager aMobManager;
    // Use this for initialization
    void Start()
    {
        timer = atkspeed;
        aMobManager = FindObjectOfType<MobManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindTime < Time.time)
        {
            FindTime = Time.time + FineTimeLength;
            ChooseNearestMob();
        }
        if (aMobManager.MobExit && target)
            followmob();
        else
            targeted = false;
        if (targeted == true)
            far_atk();
    }

    private void ChooseNearestMob()
    {
        System.Collections.Generic.List<mobcontroller> AllMob = aMobManager.AllMob;
        if (AllMob.Count == 0) { return; }
        float Nearest = Vector2.Distance(AllMob[0].transform.position, transform.position);
        target = AllMob[0].gameObject;
        for (int i = 1; i < AllMob.Count; ++i)
        {
            float d = Vector2.Distance(AllMob[i].transform.position, transform.position);
            if (d >= Nearest) { continue; }
            d = Nearest;
            target = AllMob[i].gameObject;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mob")                 //這是攻擊的時候
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Instantiate(atk, transform.position, transform.rotation);
                timer = atkspeed;
            }
        }
        else if (other.gameObject.CompareTag("atkzon"))      //這是被打到的時候
        {
            mobcontroller mc = GetComponent<mobcontroller>();
            if (mc)
            {
                hp -= mc.hurt;
                ValueShowOut.Born(gameObject, hurt);
                if (hp <= 0)
                {
                    Destroyme();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "mob")

            timer = atkspeed;
    }

    void Destroyme()
    {
        Destroy(gameObject);
    }

    void followmob()
    {
        if (type == 0)  //近戰
        {
            transform.LookAt(target.transform); //保持物件一直面朝target
            if (Vector3.Distance(transform.position, target.transform.position) > renger)
                transform.Translate(Vector3.forward * Time.deltaTime * runspeed);
        }
        else if (type == 1)  //遠程
        {
            transform.LookAt(target.transform); //保持物件一直面朝target
            if (Vector3.Distance(transform.position, target.transform.position) > renger)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * runspeed);
                targeted = false;
            }
            else
                targeted = true;
        }
    }

    void far_atk()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(faratk, transform.position, transform.rotation);
            timer = atkspeed;
        }
    }
    public void mobattack(int attack)
    {
        hp -= attack;
    }
}