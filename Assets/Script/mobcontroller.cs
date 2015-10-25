using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mobcontroller : MonoBehaviour {
    public Text mobHPText;
    public GameObject Target;
    public Transform atkzon;

    private float atkTimer;    
    private int mobHP;

    private int aaa = 0;
    GameObject model;
    // Use this for initialization
    void Start () {
        mobHP = 50;
        atkTimer = 6;
        setMobText();
        model = GameObject.Find("Mob");
    }
	
	// Update is called once per frame
	void Update () {
        run();
        if (mobHP <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerStay(Collider other)
    {              
        if (other.gameObject.CompareTag  ("attack")){
            int hurt=1;
            mobHP-=hurt;
            ValueShowOut.Born( gameObject, hurt);
            setMobText();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            atkTimer -= Time.deltaTime;
            if (atkTimer <= 0)
            {
                Instantiate(atkzon, transform.position, transform.rotation);
               // Destroy(other);
                atkTimer = 6;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            atkTimer = 6;
    }
    void setMobText()
    {
        mobHPText.text = "HP: " + mobHP.ToString();
    }
    void run()
    {
        if (aaa == 0) //如果aaa是0的狀態下
        {
            model.transform.Translate(0.05f, 0, 0);
            //model會往x軸的方向向右持續移動0.2個單位
            if (model.transform.position.x >= 3)
            //如果當model物件的x軸向右移動到3的位置
            {
                aaa = 1; //則aaa就會變成1，這時model物件就不會繼續往右移動。
            }
        }

        if (aaa == 1) //如果aaa是1的狀態下
        {
            model.transform.Translate(0, 0, 0.05f);
            //model會往z軸的方向向內持續移動0.2個單位
            if (model.transform.position.z >= 3)
            //如果當model物件的z軸向內移動到3的位置
            {
                aaa = 2; //則aaa就會變成2，這時model物件就不會繼續往內移動。
            }
        }

        if (aaa == 2) //如果aaa是2的狀態下
        {
            model.transform.Translate(-0.05f, 0, 0);
            //model會往x軸的方向向左持續移動0.2個單位
            if (model.transform.position.x <= -3)
            //如果當model物件的x軸向左移動到0的位置
            {
                aaa = 3; //則aaa就會變成3，這時model物件就不會繼續往左移動。
            }
        }

        if (aaa == 3) //如果aaa是3的狀態下
        {
            model.transform.Translate(0, 0, -0.05f);
            //model會往z軸的方向向外持續移動0.2個單位
            if (model.transform.position.z <= -3)
            //如果當model物件的z軸向右移動到0的位置
            {
                aaa = 0; //則aaa就會變成0，這時model物件就不會繼續往外移動。
            }
        }
    }

}
