using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bollcreat : MonoBehaviour {

    public GameObject Prefab;       //召喚的物件
    private string bollname;        //召喚的物件的名字

    public Text rText;              //UI的文字訊息
    public Text bText;
    public Text gText;
    
    // クリックした位置座標
    private Vector3 clickPosition;

    // Use this for initialization
    public Camera setcamera;
    private int rcount = 20;        //物件的數量
    private int bcount = 20;
    private int gcount = 20;

    // Use this for initialization
    void Start () {
        setbolltext();              //改變UI上顯示的文字
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)){

            // ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
            // Vector3でマウスがクリックした位置座標を取得する
            clickPosition = Input.mousePosition;

            // Z軸修正
            clickPosition.z = 30;

            if (bollname == "characterred")
            {
                if (rcount > 0)
                {                   
                     
                    // オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
                    // ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
                    Instantiate(Prefab, setcamera.ScreenToWorldPoint(clickPosition), Prefab.transform.rotation);
                    rcount--;
                }
            }
            else if (bollname == "characterblue") { 
            if (bcount > 0)
                {
                    Instantiate(Prefab, setcamera.ScreenToWorldPoint(clickPosition), Prefab.transform.rotation);
                    bcount--;
                }
            }
            else if (bollname == "charactergreen")
            {
                if (gcount > 0)
                {
                    Instantiate(Prefab, setcamera.ScreenToWorldPoint(clickPosition), Prefab.transform.rotation);
                    gcount--;
                }
            }
            setbolltext();
        }
    }

    public void bollchange(GameObject boll) //用來取得按鈕的事件
    {
        Prefab = boll;                      //按下按鈕之後，對應的物件會成為Prrefad
        bollname = boll.name;               //取得對應物件的名稱
    }

    void setbolltext()
    {
        rText.text = "X:" + rcount.ToString();
        gText.text = "X:" + gcount.ToString();
        bText.text = "X:" + bcount.ToString();
    }
}
