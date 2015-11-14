#region Unity
using UnityEngine;
using UnityEngine.UI;
#endregion
#region Standard
using System.Collections;
using System.Collections.Generic;
#endregion
//BGW
public partial class ValueShowOut : BGWBase
{
    public Text aText;
    public Vector3 Direction;
    public float Range = 1,FadeSpeed=0.3f;
    public static ValueShowOut m;
}
public partial class ValueShowOut : BGWBase
{
    public void Start()
    {
        Direction = new Vector3(Random.Range(-Range, Range), Random.Range(-Range, Range));
    }
    void Update()
    {
        transform.position += Direction * Time.deltaTime;
        if (aText.color.a>0)
        {
            var c= aText.color;
            c.a -= Time.deltaTime * FadeSpeed;
            aText.color = c;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetValue(int v)
    {
        aText.text = v.ToString();
    }
    /// <summary>
    /// 用來產生文字飛濺
    /// </summary>
    /// <param name="mother">從哪裡為中心點往外發出去的遊戲物件</param>
    /// <param name="v">數值</param>
    public static void Born(GameObject mother, int v)
    {
        Born(mother, v, 100, 0.5f);
    }
    /// <summary>
    /// 用來產生文字飛濺
    /// </summary>
    /// <param name="mother">從哪裡為中心點往外發出去的遊戲物件</param>
    /// <param name="v">數值</param>
    /// <param name="range">範圍(單位:視窗單位)</param>
    /// <param name="fadeSpeed">完全淡化所需時間)</param>
    public static void Born(GameObject mother, int v,float range,float fadeSpeed)
    {
        if (m==null)
        {
            m = ValueShowOut.FindObjectOfType<ValueShowOut>();
        }
        var vso = Instantiate<ValueShowOut>(m);
        vso.gameObject.name = "ValueShowOut:" + Time.time;
        vso.Range = range;
        vso.FadeSpeed = fadeSpeed;
        vso.Start();
        vso.transform.SetParent(Canvas.FindObjectOfType<Canvas>().transform);
        vso.transform.position = Camera.main.WorldToScreenPoint(mother.transform.position);
        vso.SetValue(v);
    }
}
#region Tip
//void Awake()
//void OnTriggerEnter(Collider other) 
//void OnCollisionEnter(Collision other)
#endregion
