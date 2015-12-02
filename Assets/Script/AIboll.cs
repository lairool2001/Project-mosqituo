using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIboll : MonoBehaviour
{
    //public NavMeshAgent player;
    public GameObject target;
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

    // Use this for initialization
    void Start()
    {
        timer = atkspeed;
        aMobManager = FindObjectOfType<MobManager>();
        ChooseNearestMob();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        /*if (FindTime < Time.time)
        {
            FindTime = Time.time + FineTimeLength;
            ChooseNearestMob();
        }*/
        if(!target){
            ChooseNearestMob();
        }

=======
		//Physics2D.OverlapPoint (transform.position);

        if (FindTime < Time.time)
        {
            FindTime = Time.time + FineTimeLength;
		}
		ChooseNearestMob();

        if (aMobManager.MobExit && target) {
			Collider c= target.GetComponent<Collider> ();
			bool isHit= c.bounds.Contains (transform.position);
			if (isHit) {

				if (c.gameObject.tag == "mob")                 //這是攻擊的時候
				{
					timer -= Time.deltaTime;
					if (timer <= 0)
					{
						mobcontroller mc= c.GetComponent<mobcontroller>();
						playerHit(mc.hurt);
						mc.mobHit(hurt);
						mc.TriggerStay(GetComponent<Collider>());
						//Instantiate(atk, transform.position, transform.rotation);
						timer = atkspeed;
					}
				}
			}
			followmob ();
		} else {
			targeted = false;
		}
>>>>>>> origin/master

        if (targeted == true)
            far_atk();
        if (hp <= 0)
        {
            Destroyme();
        }
    }
    void FixedUpdate(){
        if (aMobManager.MobExit && target)
            followmob();
        else
            targeted = false;
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
    }

<<<<<<< HEAD
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mob")                 //這是攻擊的時候
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                other.GetComponent<mobcontroller>().mobHit(hurt);
                //Instantiate(atk, transform.position, transform.rotation);
                timer = atkspeed;
            }
        }
=======
    //void OnTriggerStay(Collider other)
    //{
       
>>>>>>> origin/master
        /*else if (other.gameObject.CompareTag("atkzon"))      //這是被打到的時候
        {
            /*hp--;
            if (hp <= 0)
            {
                Destroyme();
            }
            mobcontroller mc = GetComponent<mobcontroller>();
            if (mc)
            {
                hp--;//= mc.hurt;
                ValueShowOut.Born(gameObject, hurt);
                if (hp <= 0)
                {
                    Destroyme();
                }
            }*/
        //}
    //}

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
    public void playerHit(int attack)
    {
        hp -= attack;
        ValueShowOut.Born(gameObject, attack);
    }
}
