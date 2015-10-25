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
    public static void Born(GameObject mother, int v)
    {
        var vso = Instantiate<ValueShowOut>(ValueShowOut.FindObjectOfType<ValueShowOut>());
        vso.Range = 100;
        vso.FadeSpeed = 0.5f;
        vso.Start();
        vso.transform.parent = Canvas.FindObjectOfType<Canvas>().transform;
        vso.transform.position = Camera.main.WorldToScreenPoint(mother.transform.position);
        vso.SetValue(v);
    }
}
#region Tip
//void Awake()
//void OnTriggerEnter(Collider other) 
//void OnCollisionEnter(Collision other)
#endregion
