using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIboll : MonoBehaviour
{
    //public NavMeshAgent player;
    public GameObject target;
    public Hitz targetHitz;
    public int targetIndex;

    public Transform atk;
    public Transform faratk;
    private float timer;
    public float hp = 5;
    public float renger = 2;//攻擊距離
    public int hurt;
    public int type;// 0 是近戰，1 是遠攻，2 是撿東西
    public float runspeed = 1.5f;
    public float atkspeed = 1.5f;

    private bool targeted = false;
    public float FindTime, FineTimeLength = 0.5f;
    public MobManager aMobManager;
    //public bool Moving;
    mobcontroller mc;
    // Use this for initialization
    void Awake(){

    }

    void Start()
    {
        timer = atkspeed;
        aMobManager = FindObjectOfType<MobManager>();
        ChooseNearestMob();
    }

    // Update is called once per frame
    void Update()
    {
		//Physics2D.OverlapPoint (transform.position);

        if (FindTime < Time.time)
        {
            FindTime = Time.time + FineTimeLength;
			if (aMobManager.MobExit && target)
            {
                Collider c = target.GetComponent<Collider>();
                bool isHit= c.bounds.Contains (transform.position);
				if (isHit)
                {
                    //這是攻擊的時候
                    if (c.gameObject.CompareTag("mob"))                 
					{
						mc= c.GetComponent<mobcontroller>();
						timer -= Time.deltaTime;
						mc.atkTimer -= Time.deltaTime;
						if (timer <= 0)
						{
							mc.Hitmob(hurt);
							timer = atkspeed;
						}
						if(mc.atkTimer <= 0){
							Hitplayer(mc.hurt);
							mc.atkTimer = 3;
						}
					}
				}
			}
		}
        if(!target){
            ChooseNearestMob();
        }

        if (aMobManager.MobExit && target) {
			followmob ();
		} else {
			targeted = false;
		}

        if (targeted == true)
            far_atk();
        if (hp <= 0)
        {
            OnDisable();
        }
    }
    
    void OnDisable(){
		this.gameObject.SetActive(false);
	}

    private void ChooseNearestMob()
    {
        System.Collections.Generic.List<mobcontroller> AllMob = aMobManager.AllMob;
        if (AllMob.Count == 0) { return; }
		float Nearest = Vector2.Distance(new Vector2( AllMob[0].transform.position.x, AllMob[0].transform.position.z),new Vector2( transform.position.x,transform.position.z));
        target = AllMob[0].gameObject;
        for (int i = 1; i < AllMob.Count; ++i)
        {
			float d = Vector2.Distance(new Vector2( AllMob[i].transform.position.x,AllMob[i].transform.position.z),new Vector2( transform.position.x,transform.position.z));
            if (d >= Nearest) { continue; }
            d = Nearest;
            target = AllMob[i].gameObject;
        }
        targetHitz = target.GetComponent<Hitz>();
        targetIndex = Random.Range(0, targetHitz.pointz.Count - 1);
    }
    void Destroyme()
    {
        Destroy(gameObject);
    }

    void followmob()
    {
        Vector3 t = target.transform.position + targetHitz.pointz[targetIndex];
        transform.LookAt(t); //保持物件一直面朝target
        if (Vector3.Distance(transform.position, target.transform.position) > renger)
            transform.Translate(Vector3.forward * Time.deltaTime * runspeed);
        /*if (type == 0)  //近戰
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
        }*/
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
    public void Hitplayer(int attack)
    {
        hp -= attack;
        ValueShowOut.Born(gameObject, attack);
    }
}
