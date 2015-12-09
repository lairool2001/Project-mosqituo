using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class bollcreat : MonoBehaviour
{

    public GameObject Prefab;       //召喚的物件
    private string bollname;        //召喚的物件的名字

    public Text rText;              //UI的文字訊息
    public Text bText;
    public Text gText;
    public Text count;

    // クリックした位置座標
    private Vector3 clickPosition;

    // Use this for initialization
    public Camera setcamera;

    private int rcount = 3000;        //物件的數量
    private int bcount = 3000;
    private int gcount = 3000;

    bool ignoreClick;

    //多點觸控測試
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchold;
    private RaycastHit hit;

	float t_start,t_end;
    // Use this for initialization
    void Start()
    {
        setbolltext();              //改變UI上顯示的文字
		t_start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (ignoreClick)
        {
            return;
        }
#if UNITY_EDITOR_WIN
        usemouse();//使用滑鼠
#endif
        touch();

    }

    public void bollchange(GameObject boll) //用來取得按鈕的事件
    {
        Prefab = boll;                      //按下按鈕之後，對應的物件會成為Prrefad
        bollname = boll.name;               //取得對應物件的名稱
    }
    public void On()
    {
        ignoreClick = true;
    }
    public void Off()
    {
        ignoreClick = false;
    }

    void setbolltext()
    {
        rText.text = "X:" + rcount.ToString();
        gText.text = "X:" + gcount.ToString();
        bText.text = "X:" + bcount.ToString();
    }

    void creat()          //生成球的程式碼
    {
        if (bollname == "characterred")
        {
            if (rcount > 0)
            {
                Instantiate(Prefab, clickPosition, Prefab.transform.rotation);
                rcount--;
            }
        }
        else if (bollname == "characterblue")
        {
            if (bcount > 0)
            {
                Instantiate(Prefab, clickPosition, Prefab.transform.rotation);
                bcount--;
            }
        }
        else if (bollname == "charactergreen")
        {
            if (gcount > 0)
            {
                Instantiate(Prefab, clickPosition, Prefab.transform.rotation);
                gcount--;
            }
        }
        setbolltext();
    }

    //使用滑鼠生成
    void usemouse(){
		t_end = Time.time;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//使用Unity內Ray變數將Camera位置到滑鼠位置轉換成一條3D射線
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))//將射線投到物件上，這裡使用物件的Tag名稱以及是否按下滑鼠左鍵作為判斷
        {
			if (Input.GetMouseButton(0) && (hit.transform.gameObject.tag == "ground" || hit.transform.gameObject.tag == "Player") && t_end - t_start >0.05)
            {
                clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                //clickPosition.y = 0.5f;// Z軸修正
				clickPosition.y += Random.Range(-0.5f , 0.5f);// Z軸亂數剛體
                                       //print(clickPosition);
				clickPosition.x += Random.Range(-1f , 1f);
				clickPosition.z += Random.Range(-1f , 1f);
                creat();
				t_start = Time.time;
            }
            /*else if (Input.GetMouseButton(0) && hit.transform.gameObject.tag == "Player")
            {
                clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                clickPosition.y = 0.5f;// Z軸修正
                                       //print(clickPosition);
                creat();
            }*/
        }
    }

    //使用觸控生成
    void touch()
    {
        if (Input.touchCount > 0)
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                touchold = new GameObject[touchList.Count];
                touchList.CopyTo(touchold);
                touchList.Clear();

                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);


                    if (Physics.Raycast(ray, out hit/*, touchInputmask*/))
                    {
                        GameObject recipient = hit.transform.gameObject;
                        touchList.Add(recipient);

                        if (hit.transform.gameObject.tag == "ground")
                        {
                            clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                            clickPosition.y = 0.5f; // Z軸修正
                                                    //print(clickPosition);
						clickPosition.y += Random.Range(-0.5f , 0.5f);// Z軸亂數剛體
						//print(clickPosition);
						clickPosition.x += Random.Range(-1f , 1f);
						clickPosition.z += Random.Range(-1f , 1f);
						creat();
						t_start = Time.time;
                        }
                        else if (hit.transform.gameObject.tag == "Player")
                        {
                            clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                            clickPosition.y = 0.5f; // Z軸修正
                                                    //print(clickPosition);
						clickPosition.y += Random.Range(-0.5f , 0.5f);// Z軸亂數剛體
						//print(clickPosition);
						clickPosition.x += Random.Range(-1f , 1f);
						clickPosition.z += Random.Range(-1f , 1f);
						creat();
						t_start = Time.time;
                        }

                        /* if (touch.phase == TouchPhase.Began)
                         {
                             recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                         }
                         if (touch.phase == TouchPhase.Ended)
                         {
                             recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                         }
                         if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                         {
                             recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                         }
                         if (touch.phase == TouchPhase.Canceled)
                         {
                             recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                         }*/
                        //}
                    }
                    foreach (GameObject g in touchold)
                    {
                        if (!touchList.Contains(g))
                        {
                            g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
    }
}
