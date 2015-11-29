using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mobcontroller : MonoBehaviour {
    public Text mobHPText;
    public GameObject Target;
    public Transform atkzon;
    //trigger mcollider;
    public GameObject mco;

    public bool isAttack=false;
    private float atkTimer;
    public int mobHP=50;
    public int hurt = 1;

    GameObject model;
    Vector3 test;

    private int i_RandomStatus;
    private int i_Mile;
    private float i_Direntionx;
    private float i_Direntionz;
    float f_Distance;
    // Use this for initialization
    void Start () {
        i_RandomStatus = Random.Range(0, 4);
        i_Mile = Random.Range(1, 3);
        i_Direntionx = Random.Range(-0.1f, 0.1f);
        i_Direntionz = Random.Range(-0.1f, 0.1f);
        //mobHP = 50;
        atkTimer = 3;
        setMobText();
        model = GameObject.Find("Mob");
        model = gameObject;
        test = model.transform.localPosition;
        //mcollider = GameObject.Find("hitcollider").GetComponent<trigger>();
        //mcollider.sethit(hurt);
        //trigger mobset = GetComponent<trigger>();
        mco.GetComponent<trigger>().sethit(hurt);
    }

	// Update is called once per frame
	void Update () {
        mobHPText.rectTransform.position = Camera.main.WorldToScreenPoint(model.transform.position);
        run(test);
        if (mobHP <= 0)
        {
            Destroy(gameObject);
        }
        /*if(isAttack){
            for(atkTimer;atk)
            atkTimer -= Time.deltaTime;
            if(atkTimer <= 0){
                mcollider.GetComponent<Collider>().enabled = true;
            }
        }*/
	}

    void OnDestroy()
    {
        SendMessageUpwards("OnMobDie", this, SendMessageOptions.DontRequireReceiver);
    }
    
    void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.CompareTag  ("attack")){

            mobHP-=hurt;
            ValueShowOut.Born( gameObject, hurt);
            setMobText();
        }
        else */if (other.gameObject.CompareTag("Player"))
        {
            //isAttack=true;
            atkTimer -= Time.deltaTime;
            if (atkTimer <= 0)
                {
                other.GetComponent<AIboll>().playerHit(hurt);

                /*Instantiate(atkzon, transform.position, transform.rotation);
                Destroy(other);*/
                atkTimer = 3;
                }
        }
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(3);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            //atkTimer = 6;
            isAttack=false;
    }
    void setMobText()
    {
        mobHPText.text = "HP: " + mobHP.ToString();
    }
    void run(Vector3 vec3)
    {
		//決定了移動的方向 但也會影響到移動速度(必須解決)
        model.transform.Translate(i_Direntionx, 0, i_Direntionz);
		//用畢氏定理算移動距離
        f_Distance=Mathf.Pow(Mathf.Pow(Mathf.Abs(model.transform.position.x - vec3.x),2)+Mathf.Pow(Mathf.Abs(model.transform.position.y - vec3.y),2),0.5f);

        //不讓他跑出去特定範圍的if條件
        if (f_Distance >= i_Mile || model.transform.position.x > 10 || model.transform.position.x < -10 || model.transform.position.z > 10 || model.transform.position.z < -10)
        //用下面這個會亂跑喔
		//if (f_Distance >= i_Mile )
        {
			//有關test的可以先不要理會 我是在測試一些其它辦法
            test = model.transform.localPosition;
            i_RandomStatus = Random.Range(0, 4);
            i_Mile = Random.Range(3, 5);
            do
            {
                i_Direntionx = Random.Range(-0.1f, 0.1f);
                i_Direntionz = Random.Range(-0.1f, 0.1f);
                //BroadcastMessage("" + i_Direntionx + "," + i_Direntionx);
            } while (i_Direntionx < -0.05f || i_Direntionx > 0.05f || i_Direntionz < -0.05f || i_Direntionz > 0.05f);//限定他的速度範圍 希望能讓其中一項= 0.1或-0.1 但有點問題
        }
    }

    public void mobHit(int _minus){
        mobHP -= _minus;
        ValueShowOut.Born( gameObject, _minus);
        setMobText();
    }
}
