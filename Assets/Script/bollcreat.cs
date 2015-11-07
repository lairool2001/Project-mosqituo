using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bollcreat : MonoBehaviour
{

    public GameObject Prefab;       //召喚的物件
    private string bollname;        //召喚的物件的名字

    public Text rText;              //UI的文字訊息
    public Text bText;
    public Text gText;

    // クリックした位置座標
    private Vector3 clickPosition;

    // Use this for initialization
    public Camera setcamera;
    private int rcount = 3000;        //物件的數量
    private int bcount = 3000;
    private int gcount = 3000;
    bool ignoreClick;
    // Use this for initialization
    void Start()
    {
        setbolltext();              //改變UI上顯示的文字
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//使用Unity內Ray變數將Camera位置到滑鼠位置轉換成一條3D射線
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))//將射線投到物件上，這裡使用物件的Tag名稱以及是否按下滑鼠左鍵作為判斷
        {
            if (Input.GetMouseButton(0) && hit.transform.gameObject.tag == "ground")
            {
                if (ignoreClick)
                {
                    return;
                }

                clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                clickPosition.y = 0.5f;// Z軸修正
                print(clickPosition);

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
        }
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
}
